using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume.Areas.Admin.Models;

namespace ShopManagementMVCConsume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        // GET: Admin/Users
        public async Task<IActionResult> Get()
        {
            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("Users");

            IEnumerable<User> users = new List<User>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<IEnumerable<User>>(result);
            }

            ViewData.Model = users;

            return View();
        }

        public async Task<IActionResult> Insert(User user)
        {
            HttpResponseMessage response = await GloblaVariables.PostResponseAsync("Users", user);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Get", "Users");
            }

            return View();
        }
    }
}
