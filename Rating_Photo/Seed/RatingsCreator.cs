using Rating_Photo.DBContext;
using Rating_Photo.Models.Authomation;

namespace Rating_Photo.Seed
{
    public class RatingsCreator
    {
        private readonly RatingSystemDbContext _ratingSystemDb;
        public RatingsCreator(RatingSystemDbContext ratingSystemDb)
        {
            _ratingSystemDb = ratingSystemDb;
        }

        public void Create()
        {
            CreateRating();
        }

        private void CreateRating()
        {
            if (!_ratingSystemDb.Rating.Any())
            {
                _ratingSystemDb.Rating.AddRange(
                    new Rating { RateValue = RatingValue.High, CreatedAt = DateTime.UtcNow, LastUpdatedAt = DateTime.UtcNow, UserId = 5, ImageId = 5 },
                    new Rating { RateValue = RatingValue.Low, CreatedAt = DateTime.UtcNow, LastUpdatedAt = DateTime.UtcNow, UserId = 6, ImageId = 6 }
                );
            }
        }
    }


}
