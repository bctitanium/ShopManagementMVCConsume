using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume.Areas.Admin.Models;

namespace ShopManagementMVCConsume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        // GET: Admin/Category
        public async Task<IActionResult> Get()
        {
            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("Category");

            IEnumerable<Category> categories = new List<Category>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(result);
            }

            ViewData.Model = categories;

            return View();
        }

        public async Task<IActionResult> Insert(Category category)
        {
            HttpResponseMessage response = await GloblaVariables.PostResponseAsync("Category", category);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Get", "Category");
            }

            return View();
        }
    }
}
