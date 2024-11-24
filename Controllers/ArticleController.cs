using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Data;
using NewsWebApp.Models;

namespace NewsWebApp.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ArticleController(ApplicationDBContext db)
        {
            _db = db;
        }

        // gets the id number and fetches the article with the corresponding id number from the database,
        // and returns the index view for the article with that id number
        public IActionResult Index(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Article? articleFromDB = _db.Articles.Find(id);
            if (articleFromDB == null)
            {
                return NotFound();
            }
            return View(articleFromDB);
        }
    }
}
