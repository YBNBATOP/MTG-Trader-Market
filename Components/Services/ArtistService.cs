using MTGTraderMarket.Models;

namespace MTGTraderMarket.Models
{
    public class ArtistService
    {
        private readonly DBContext dbContext;

        public ArtistService()
        {
            dbContext = new DBContext();
        }

        public Artist? GetArtistById(long? id)
        {
            return dbContext.Artists.Find(id);
        }
    }
}
