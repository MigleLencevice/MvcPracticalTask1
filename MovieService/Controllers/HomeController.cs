using Microsoft.AspNetCore.Mvc;

namespace MovieService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}