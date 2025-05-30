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

        // Index method can take input parameters term, OrderBy and CurrentPage to
        // implement Search, Sort and Pagination functions respectively
        // when a term is provided, looks for for any articles with titles containing the term
        // when the hyperlink on top of Id column is clicked, sorts articles based on descending ID
        // default currentPage is set to 1
        // calculates the totalPages
        // selects the 10 articles for any given current page skipping the articles
        // for other previous pages and sends all the parameters to the viewmodel
        // for pagination in the view, the for loop iterates from 1 to total pages
        // the previous like hyperlinks to currentpage-1, the next hyperlinks to currentpage+1
        // Todo: make the number of pages displayed in pagination be like 4-5 closest from current
        // page instead of printing all the pages
        public IActionResult Index(string term="", string orderBy="", int currentPage=1)
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

            int totalRecords = articles.Count();
            int pageSize = 10;
            int totalPages = (int) Math.Ceiling(totalRecords / (double) pageSize);

            articleData.Articles = articles.Skip((currentPage - 1) * pageSize).Take(pageSize);
            articleData.CurrentPage = currentPage;
            articleData.TotalPages = totalPages;
            articleData.PageSize = pageSize;
            articleData.Term = term;
            articleData.OrderBy = orderBy;

            return View(articleData);
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
