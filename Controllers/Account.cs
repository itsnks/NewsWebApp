using Microsoft.AspNetCore.Mvc;

namespace NewsWebApp.Controllers
{
    public class Account : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
