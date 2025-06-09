using Microsoft.AspNetCore.Mvc;

namespace MovieStar.API.Controllers
{
    public class FilmesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
