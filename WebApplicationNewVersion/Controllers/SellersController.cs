using Microsoft.AspNetCore.Mvc;

namespace WebApplicationNewVersion.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
