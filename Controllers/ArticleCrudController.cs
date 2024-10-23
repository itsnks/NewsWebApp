﻿using Microsoft.AspNetCore.Mvc;
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
    }
}