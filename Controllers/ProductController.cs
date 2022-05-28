using Microsoft.AspNetCore.Mvc;

namespace ShopManagementMVCConsume.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
