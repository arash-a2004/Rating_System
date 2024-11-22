using src.Data;
using src.Models;
namespace src.Seed
{
    public class ImageCreator
    {
        private readonly ApplicationDbContext _ratingSystemDb;
        public ImageCreator(ApplicationDbContext ratingSystemDb)
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
                    new models.Image { Image_Description = "Sunset", ImageURL = @"C:\Users\AsusIran\Pictures\Screenshots\1.png" },
                    new models.Image { Image_Description = "Mountain", ImageURL = @"C:\Users\AsusIran\Pictures\Screenshots\2.png" },
                    new models.Image { Image_Description = "Mountain1", ImageURL = @"C:\Users\AsusIran\Pictures\Screenshots\3.png" },
                    new models.Image { Image_Description = "Mountain2", ImageURL = @"C:\Users\AsusIran\Pictures\Screenshots\4.png" }
                );
            }
        }

    }
}
