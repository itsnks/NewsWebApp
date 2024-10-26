using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Data;
using NewsWebApp.Models;

namespace NewsWebApp.Controllers
{
    public class ArticleCrudController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ArticleCrudController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Article> ArticleList = _db.Articles.OrderBy(obj => obj.DisplayOrder).ToList();
            return View(ArticleList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Article obj)
        {
            if (ModelState.IsValid)
            {
                _db.Articles.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Article Created Successfully!";
                return RedirectToAction("Index", "ArticleCrud");
            }
            return View();
        }
        public IActionResult Edit(int? id)
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

        [HttpPost]
        public IActionResult Edit(Article obj)
        {
            if (ModelState.IsValid)
            {
                _db.Articles.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully!";
                return RedirectToAction("Index", "ArticleCrud");
            }
            return View();
        }
        public IActionResult Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Article? obj = _db.Articles.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Articles.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Article Deleted Successfully!";
            return RedirectToAction("Index");
        }
    }
}
