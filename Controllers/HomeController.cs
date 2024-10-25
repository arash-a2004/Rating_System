using Microsoft.AspNetCore.Mvc;
using Rating_Photo.DBContext;
using Rating_Photo.Models;
using System.Diagnostics;

namespace Rating_Photo.Controllers
{
    public class HomeController : Controller
    {
        private readonly RatingSystemDbContext _systemDbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,RatingSystemDbContext ratingSystemDbContext)
        {
            _logger = logger;
            _systemDbContext = ratingSystemDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
