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

        public async Task<IActionResult> Login(Login login)
        {
            HttpResponseMessage response = await GloblaVariables.PostResponseAsync("Auth/login", login);

            if (response.IsSuccessStatusCode && login.UserName == "admin1")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
