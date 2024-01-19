using LicentaApp.Data;
using LicentaApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var restaurants = db.Restaurants;
            ViewBag.Restaurants = restaurants;

            return View();
        }
        public IActionResult Show(Guid id)
        {
            Restaurant rest = db.Restaurants.Include("MenuProducts")
                                            .Include("MenuProducts.Product")
                                            .Where(r => r.Id == id)
                                            .First();

            return View(rest);
        }
    }
}
