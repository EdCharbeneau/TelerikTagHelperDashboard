using Microsoft.AspNetCore.Mvc;

namespace TelerikAspNetCoreApp1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
