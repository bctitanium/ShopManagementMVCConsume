using Microsoft.AspNetCore.Mvc;

namespace ShopManagementMVCConsume.Controllers
{
    public class DressUpController : Controller
    {
        public IActionResult Dress()
        {
            return View();
        }
    }
}
