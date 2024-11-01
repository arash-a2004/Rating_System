using src.DBContext;

namespace src.Seed
{
    public class InitialHostDbBuilder
    {
        private readonly RatingSystemDbcontext _ratingSystemDb;
        public InitialHostDbBuilder(RatingSystemDbcontext ratingSystemDb)
        {
            _ratingSystemDb = ratingSystemDb;
        }
        public async void Create()
        {
            _ratingSystemDb.Database.EnsureCreated();
            //new UserCreator(_ratingSystemDb).Create();
            new ImageCreator(_ratingSystemDb).Create();
            //new RatingsCreator(_ratingSystemDb).Create();

            _ratingSystemDb.SaveChanges();

        }
    }
}
