using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Data;
using NewsWebApp.Models.Entities;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Controllers
{
    [Authorize(Roles = "Creator,Admin")]
    public class ArticleCrudController : Controller
    {
        private readonly ApplicationDBContext _db;
        public ArticleCrudController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index(string term="", string orderBy="")
        {
            term = string.IsNullOrEmpty(term)?"":term.ToLower();

            var articleData = new DashboardViewModel();
            articleData.IdSortOrder = string.IsNullOrEmpty(orderBy) ? "id_asc" : "";

            var articles = (from article in _db.Articles
                            where term=="" || article.Title.ToLower().Contains(term)
                            select new Article
                            {
                                Id = article.Id,
                                Title = article.Title

                            }).OrderByDescending(u => u.Id);
            switch (orderBy)
            {
                case "id_asc":
                    articles = articles.OrderBy(u => u.Id); break;
                default:
                    articles = articles.OrderByDescending(u => u.Id); break;
            }
            articleData.Articles = articles;
            return View(articleData);

            /*List<Article> ArticleList = _db.Articles.OrderByDescending(obj => obj.Id).ToList();
            List<DashboardViewModel> ViewModelList = ArticleList.Select(u => new DashboardViewModel(u)).ToList();
            return View(ViewModelList);*/
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
                TempData["success"] = "Article Updated Successfully!";
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
