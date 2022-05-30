using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume.Areas.Admin.Models;

namespace ShopManagementMVCConsume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly ILogger<RolesController> _logger;

        public RolesController(ILogger<RolesController> logger)
        {
            _logger = logger;
        }

        // GET: Admin/Roles
        public async Task<IActionResult> Get()
        {
            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("Roles");

            IEnumerable<Role> roles = new List<Role>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                roles = JsonConvert.DeserializeObject<IEnumerable<Role>>(result);
            }

            ViewData.Model = roles;

            return View();
        }

        public async Task<IActionResult> Insert(Role role)
        {
            HttpResponseMessage response = await GloblaVariables.PostResponseAsync("Roles", role);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Get", "Roles");
            }

            return View();
        }
    }
}
