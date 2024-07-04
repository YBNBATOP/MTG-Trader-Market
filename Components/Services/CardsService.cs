using Microsoft.EntityFrameworkCore;
using MTGTraderMarket.Models;

namespace MTGTraderMarket.Models;

public class CardsService
{
    private readonly DBContext dbContext;

    public CardsService()
    {
        dbContext = new DBContext();
    }

    public IQueryable<Card> GetCards(int amount)
    {
        IQueryable<Card> allCards = dbContext.Cards
            .Where(card => card.OriginalImageUrl != null)
            .Select(card => new Card
            {
                MtgId = card.MtgId,
                Name = card.Name,
                OriginalImageUrl = card.OriginalImageUrl != null ? card.OriginalImageUrl : "images/unkown-card.png",
                ConvertedManaCost = card.ConvertedManaCost,
                RarityCode = card.RarityCode,
                Type = card.Type,
                Toughness = card.Toughness,
                Power = card.Power,
                SetCode = card.SetCode
            })
              .Take(amount);
        return allCards;
    }


    public IQueryable<Card> GetCardByMTGId(string mtgId)
    {
        return dbContext.Cards
            .Where(card => card.MtgId == mtgId && card.OriginalImageUrl != null)
            .Select(card => new Card
            {
                MtgId = card.MtgId,
                Name = card.Name,
                OriginalImageUrl = card.OriginalImageUrl != null ? card.OriginalImageUrl : "images/unkown-card.png",
                Type = card.Type != null ? card.Type : "Unkown type",
                Toughness = card.Toughness != null ? card.Toughness : "Not applicable",
                Power = card.Power != null ? card.Power : "Not applicable",
                ArtistId = card.ArtistId != null ? card.ArtistId : 0,
                RarityCode = card.RarityCode != null ? card.RarityCode : "Unknown rarity",
                Text = card.Text != null ? card.Text : "No description available",
                Flavor = card.Flavor != null ? card.Flavor : "No flavor available",
                Number = card.Number != null ? card.Number : "Unknown number",
                ManaCost = card.ManaCost != null ? card.ManaCost : "Unknown mana cost"
            });
    }

    public IQueryable<Card> GetCardBySearchFilters(string searchQuery, string rarityCode, string setCode, string typeName, int amountOfCards)
    {
        IQueryable<Card> allCards = dbContext.Cards
        .Where(card => card.OriginalImageUrl != null)
            .Where(card => searchQuery != "" ? card.Name.Contains(searchQuery) : true)
            .Where(card => rarityCode != "" ? card.RarityCode == rarityCode  : true)
            .Where(card => setCode != "" ? card.SetCode.Contains(setCode)  : true)
            .Where(card => typeName != "" ? card.Type.Contains(typeName)  : true)
            .Select(card => new Card
            {
                MtgId = card.MtgId,
                Name = card.Name,
                OriginalImageUrl = card.OriginalImageUrl != null ? card.OriginalImageUrl : "images/unkown-card.png",
                ConvertedManaCost = card.ConvertedManaCost,
                RarityCode = card.RarityCode,
                Type = card.Type,
                Toughness = card.Toughness,
                Power = card.Power,
                SetCode = card.SetCode
            })
            .Take(amountOfCards);
            return allCards;
    }
}