using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    [Authorize]
    public class Test : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Test/ExamPage.cshtml");
        }
    }
}
