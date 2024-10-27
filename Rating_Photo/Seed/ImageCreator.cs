using Rating_Photo.DBContext;
using Rating_Photo.Models.Authomation;

namespace Rating_Photo.Seed
{
    public class ImageCreator
    {
        private readonly RatingSystemDbContext _ratingSystemDb;
        public ImageCreator(RatingSystemDbContext ratingSystemDb)
        {
            _ratingSystemDb = ratingSystemDb;
        }

        public void Create()
        {
            CreateImage();
        }

        private void CreateImage()
        {
            if (!_ratingSystemDb.Images.Any())
            {
                _ratingSystemDb.Images.AddRange(
                    new Image { Image_Description = "Sunset", ImageFile = new byte[] { 0x20, 0x21 } },
                    new Image { Image_Description = "Mountain", ImageFile = new byte[] { 0x20, 0x22 } }
                );
            }
        }
    }


}
