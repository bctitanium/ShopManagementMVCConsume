using Microsoft.AspNetCore.Mvc;
using ShopManagementMVCConsume.Models;
using ShopManagementMVCConsume.Models.Create;

namespace ShopManagementMVCConsume.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> Login(Login login)
        {
            HttpResponseMessage response = await GloblaVariables.PostResponseAsync("Auth/login", login);
            string rs = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode && rs.Contains("Staff"))
            {
                //return RedirectToAction("Index", "Home");
                return Redirect("/Admin/Home/Index");
            }

            if (response.IsSuccessStatusCode && rs.Contains("Customer"))
            {
                return RedirectToAction("Get", "Product");
            }

            return View();
        }

        public async Task<IActionResult> Register(CreateUserDTO createUserDTO)
        {
            HttpResponseMessage response = await GloblaVariables.PostResponseAsync("Customer", createUserDTO);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}
