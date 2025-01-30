using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Data;
using NewsWebApp.Models;
using NewsWebApp.Models.Entities;
using System.Diagnostics;

namespace NewsWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _db;

        public HomeController(ApplicationDBContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

//  Returns the top 20 articles as a list object based on DisplayOrder whenever index view of home controller is called
//  Does the same for every other view by selecting the Articles based on their category.
        public IActionResult Index()
        {
            List<Article> ArticleList = _db.Articles.OrderByDescending(obj => obj.Id).Take(20).ToList();
            return View(ArticleList);
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Politics()
        {
            List<Article> PoliticsArticleList = _db.Articles.Where(u => u.Category == "Politics").OrderByDescending(obj => obj.Id).Take(20).ToList();
            return View(PoliticsArticleList);
        }
        public IActionResult Entertainment()
        {
            List<Article> EntertainmentArticleList = _db.Articles.Where(u => u.Category == "Entertainment").OrderByDescending(obj => obj.Id).Take(20).ToList();
            return View(EntertainmentArticleList);
        }
        public IActionResult Sports()
        {
            List<Article> SportsArticleList = _db.Articles.Where(u => u.Category == "Sports").OrderByDescending(obj => obj.Id).Take(20).ToList();
            return View(SportsArticleList);
        }
        public IActionResult Technology()
        {
            List<Article> TechnologyArticleList = _db.Articles.Where(u => u.Category == "Technology").OrderByDescending(obj => obj.Id).Take(20).ToList();
            return View(TechnologyArticleList);
        }
        public IActionResult Business()
        {
            List<Article> BusinessArticleList = _db.Articles.Where(u => u.Category == "Business").OrderByDescending(obj => obj.Id).Take(20).ToList();
            return View(BusinessArticleList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
