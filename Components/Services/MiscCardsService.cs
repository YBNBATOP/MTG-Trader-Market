using Microsoft.EntityFrameworkCore;
using MTGTraderMarket.Models;

namespace MTGTraderMarket.Models
{
    public class MiscCardsService
    {
        private readonly DBContext dbContext;

        public MiscCardsService()
        {
            dbContext = new DBContext();
        }

        public IQueryable<Rarity> GetRarities()
        {
            IQueryable<Rarity> rarities = dbContext.Rarities
            .Select(rarity => new Rarity
            {
                Code = rarity.Code,
                Name = rarity.Name
            });
            return rarities;
        }

        public IQueryable<Set> GetSets()
        {
            IQueryable<Set> sets = dbContext.Sets
            .Select(set => new Set
            {
                Code = set.Code,
                Name = set.Name
            });
            return sets;
        }

        public IQueryable<Type> GetTypes()
        {
            IQueryable<Type> types = dbContext.Types
            .Where(type => type.Type1 == "normal")
            .Select(type => new Type
            {
                Name = type.Name
            });
            return types;
        }
    }
}