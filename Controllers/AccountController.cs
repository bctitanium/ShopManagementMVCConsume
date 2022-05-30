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

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> Register(CreateUserDTO createUserDTO)
        {
            HttpResponseMessage response = await GloblaVariables.PostResponseAsync("Users", createUserDTO);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}
