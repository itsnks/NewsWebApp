using Microsoft.AspNetCore.Mvc;

namespace NewsWebApp.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
