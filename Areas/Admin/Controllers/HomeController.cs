using Microsoft.AspNetCore.Mvc;

namespace ShopManagementMVCConsume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }
    }
}
