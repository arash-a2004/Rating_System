using Rating_Photo.Models.DTO;

namespace Rating_Photo.Services.ImageServices
{
    public interface IRatingServices
    {
        Task Rating(int imageId, int userId, RatingDto ratingDto);
    }
}