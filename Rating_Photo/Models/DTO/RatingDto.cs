using Rating_Photo.Models.Authomation;

namespace Rating_Photo.Models.DTO
{
    public sealed class RatingDto
    {
        public RatingValue? RateValue { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public UserDto User { get; set; }
        public RatingDto()
        {
            User = new UserDto();
        }
    }

}
