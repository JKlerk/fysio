using Microsoft.AspNetCore.Mvc;

namespace Fysio.Controllers
{
    public class DashboardController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}