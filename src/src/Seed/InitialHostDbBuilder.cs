using src.Data;

namespace src.Seed
{
    public class InitialHostDbBuilder
    {
        private readonly ApplicationDbContext _ratingSystemDb;
        public InitialHostDbBuilder(ApplicationDbContext ratingSystemDb)
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
