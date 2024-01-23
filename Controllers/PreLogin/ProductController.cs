using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers.PreLogin
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
