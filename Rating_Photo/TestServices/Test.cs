using Rating_Photo.Models.DTO;
using Rating_Photo.Services.ImageServices;
using System.Text.Json;

namespace Rating_Photo.TestServices
{
    public class Test
    {
        private readonly IImageService _ImageService;
        private readonly IRatingServices _ratingServices;

        public Test(IImageService imageService,IRatingServices ratingServices)
        {
            _ImageService = imageService;
            _ratingServices = ratingServices;
        }

        #region ImageServices
        public async Task GetAllImageTest()
        {
            var a = await _ImageService.GetAllImage();

            var b = JsonSerializer.Serialize(a);

            Console.WriteLine(b);
        }

        public async Task GetImageDetailByIdTest(int id)
        {
            var a = await _ImageService.GetImageDetailById(id);

            var b = JsonSerializer.Serialize(a);

            Console.WriteLine(b);

        }
        #endregion

        #region Rating
        public async Task RatingTest()
        {

            RatingDto ratingDto = new()
            {
                RateValue = Models.Authomation.RatingValue.NoOpinion,
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
            };

            await _ratingServices.Rating(5, 5, ratingDto);
        }
        #endregion

    }
}
