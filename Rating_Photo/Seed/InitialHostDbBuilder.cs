using Rating_Photo.DBContext;

namespace Rating_Photo.Seed
{
    public class InitialHostDbBuilder
    {
        private readonly RatingSystemDbContext _ratingSystemDb;
        public InitialHostDbBuilder(RatingSystemDbContext ratingSystemDb)
        {
            _ratingSystemDb = ratingSystemDb;
        }
        public async void Create()
        {
            _ratingSystemDb.Database.EnsureCreated();
            new UserCreator(_ratingSystemDb).Create();    
            new ImageCreator(_ratingSystemDb).Create();    
            new RatingsCreator(_ratingSystemDb).Create();   
            
             _ratingSystemDb.SaveChanges();

        }
    }
}
