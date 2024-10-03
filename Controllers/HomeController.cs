using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Data;
using NewsWebApp.Models;
using System.Diagnostics;

namespace NewsWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        private readonly ApplicationDBContext _db;
        public HomeController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Article> objArticleList = _db.Articles.OrderBy(obj => obj.DisplayOrder).Take(20).ToList();
            return View(objArticleList);
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
