using Microsoft.EntityFrameworkCore;
using Rating_Photo.DBContext;
using Rating_Photo.Exeptions;
using Rating_Photo.Models.Authomation;
using Rating_Photo.Models.DTO;

namespace Rating_Photo.Services.ImageServices
{
    public class RatingServices : IRatingServices
    {
        private readonly RatingSystemDbContext _dbcontext;
        public RatingServices(RatingSystemDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        //User Can Submit a rate for a product 
        public async Task Rating(int imageId, int userId, RatingDto ratingDto)
        {
            var query = _dbcontext.Images
                .Include(e => e.RatingProp)
                    .ThenInclude(e => e.user)
                .Where(x => x.Id == imageId);

            var query2 = _dbcontext.Users
                .Include(e => e.Ratings)
                .Where(x => x.Id == userId);

            var user = await query2.FirstOrDefaultAsync();
            var image = await query.FirstOrDefaultAsync();

            if (user == null)
            {
                throw new UserNotfoundExeption($"there is No User with Id = {userId}");

            }

            if (image == null)
            {
                throw new ImageNotFoundExeption($"there is No Image with Id = {imageId}");
            }

            Rating rating = new();

            rating.UserId = userId;
            rating.RateValue = ratingDto.RateValue;

            rating.RatedImage = image;
            rating.user = user;

            rating.CreatedAt = ratingDto.CreatedAt;
            rating.LastUpdatedAt = ratingDto.LastUpdatedAt;

            _dbcontext.Rating.Add(rating);

            await _dbcontext.SaveChangesAsync();

        }
    }
}
