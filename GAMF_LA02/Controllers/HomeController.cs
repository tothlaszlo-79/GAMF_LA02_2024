using GAMF_LA02.Data;
using GAMF_LA02.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GAMF_LA02.Controllers
{
    public class HomeController : Controller
    {
        private readonly GAMFDbContext _context;

        public HomeController(GAMFDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var teszt = _context.Courses.ToList();
            return View();
        }

    }
}
