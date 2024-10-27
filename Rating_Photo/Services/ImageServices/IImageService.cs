using Rating_Photo.Models.DTO;

namespace Rating_Photo.Services.ImageServices
{
    public interface IImageService
    {
        Task<List<ImagesDto>> GetAllImage();
        Task<ImagesDto> GetImageDetailById(int id);
        Task UploadNewImage(ImagesDto newImage);
    }
}