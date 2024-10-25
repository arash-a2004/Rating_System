using Microsoft.EntityFrameworkCore;
using Rating_Photo.DBContext;
using Rating_Photo.Exeptions;
using Rating_Photo.Models.DTO;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Rating_Photo.Services.ImageServices
{
    public class ImageService : IImageService
    {
        private readonly RatingSystemDbContext _dbcontext;
        public ImageService(RatingSystemDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        //Get all image with their rate
        public async Task<List<ImagesDto>> GetAllImage()
        {
            var query = _dbcontext.Images.AsQueryable()
                .Include(e => e.RatingProp)
                    .ThenInclude(e => e.user)
                .Select(e => new
                {
                    Image_Description = e.Image_Description,
                    ImageFile = e.ImageFile,
                    Rate = e.RatingProp
                });

            var result = await query.ToListAsync();

            List<ImagesDto> resultDto = new();

            foreach (var image in result)
            {
                ImagesDto imagesDto = new();

                imagesDto.Image_Description = image.Image_Description;
                imagesDto.ImageFile = image.ImageFile;
                imagesDto.Rate.RateValue = image.Rate.RateValue;
                imagesDto.Rate.CreatedAt = image.Rate.CreatedAt;
                imagesDto.Rate.LastUpdatedAt = image.Rate.LastUpdatedAt;
                imagesDto.Rate.User.UserName = image.Rate.user.UserName;
                imagesDto.Rate.User.Email = image.Rate.user.Email;
                imagesDto.Rate.User.CreateAt = image.Rate.user.CreateAt;

                resultDto.Add(imagesDto);
            }

            return resultDto;
        }

        //Get image With Id
        public async Task<ImagesDto> GetImageDetailById(int id)
        {

            var query = _dbcontext.Images
                .Include(e => e.RatingProp)
                    .ThenInclude(e => e.user)
                .Where(x => x.Id == id)
                .Distinct()
                .Select(e => new
                {
                    Image_Description = e.Image_Description,
                    ImageFile = e.ImageFile,
                    Rate = e.RatingProp
                });

            var result = await query.FirstOrDefaultAsync();

            if (result == null)
            {
                throw new ImageNotFoundExeption($"there is No Image with Id = {id}");
            }

            ImagesDto imagesDto = new();

            imagesDto.Image_Description = result.Image_Description;
            imagesDto.ImageFile = result.ImageFile;
            imagesDto.Rate.RateValue = result.Rate.RateValue;
            imagesDto.Rate.CreatedAt = result.Rate.CreatedAt;
            imagesDto.Rate.LastUpdatedAt = result.Rate.LastUpdatedAt;
            imagesDto.Rate.User.UserName = result.Rate.user.UserName;
            imagesDto.Rate.User.Email = result.Rate.user.Email;
            imagesDto.Rate.User.CreateAt = result.Rate.user.CreateAt;

            return imagesDto;
        }


        public async Task UploadNewImage(ImagesDto newImage)
        {
            //TODO
        }

    }
}
