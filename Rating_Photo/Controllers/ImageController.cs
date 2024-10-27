using Microsoft.AspNetCore.Mvc;
using Rating_Photo.Services.ImageServices;

namespace Rating_Photo.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var images = _imageService.GetAllImage();
            return View(images);
        }
        [HttpGet]
        public IActionResult Details(int imageId)
        {
            var image = _imageService.GetImageDetailById(imageId);

            return View(image);
        }


    }
}
