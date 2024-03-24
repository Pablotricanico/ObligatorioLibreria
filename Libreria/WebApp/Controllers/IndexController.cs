using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
