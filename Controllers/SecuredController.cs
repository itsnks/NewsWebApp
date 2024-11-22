using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NewsWebApp.Controllers
{
    [Authorize]
    public class SecuredController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
