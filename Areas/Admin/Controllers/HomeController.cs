using Microsoft.AspNetCore.Mvc;
using ShopManagementMVCConsume.Areas.Admin.Models;

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
