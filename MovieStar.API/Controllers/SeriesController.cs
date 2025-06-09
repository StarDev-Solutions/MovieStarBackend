using Microsoft.AspNetCore.Mvc;

namespace MovieStar.API.Controllers
{
    public class SeriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
