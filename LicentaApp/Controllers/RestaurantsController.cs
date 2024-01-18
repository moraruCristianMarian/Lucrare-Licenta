using LicentaApp.Data;
using LicentaApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LicentaApp.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly ApplicationDbContext db;

        public RestaurantsController(
            ApplicationDbContext context
            )
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Show(Guid id)
        {
            Restaurant rest = db.Restaurants.Where(r => r.Id == id)
                                            .First();

            return View(rest);
        }
    }
}
