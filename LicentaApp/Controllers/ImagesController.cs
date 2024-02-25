using LicentaApp.Data;
using LicentaApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LicentaApp.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ApplicationDbContext db;

        public ImagesController(
            ApplicationDbContext context
            )
        {
            db = context;
        }

    }
}
