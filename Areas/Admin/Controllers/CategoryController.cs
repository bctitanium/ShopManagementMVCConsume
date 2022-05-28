using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume;
using ShopManagementMVCConsume.Areas.Admin.Models;
using System.Net.Http.Headers;

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

        // GET: Admin/Products
        public async Task<IActionResult> Get()
        {
            HttpResponseMessage response = await GloblaVariables.ResponseAsync("Category");

            IEnumerable<Category> categories = new List<Category>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(result);
            }

            ViewData.Model = categories;

            return View();
        }
    }
}
