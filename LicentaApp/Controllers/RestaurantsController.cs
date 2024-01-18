using Microsoft.AspNetCore.Mvc;

namespace LicentaApp.Controllers
{
    public class RestaurantsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
