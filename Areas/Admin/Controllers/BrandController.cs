using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume;
using ShopManagementMVCConsume.Areas.Admin.Models;
using System.Net.Http.Headers;

namespace ShopManagementMVCConsume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly ILogger<BrandController> _logger;

        public BrandController(ILogger<BrandController> logger)
        {
            _logger = logger;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Get()
        {
            HttpResponseMessage response = await GloblaVariables.ResponseAsync("Brand");

            IEnumerable<Brand> brand = new List<Brand>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                brand = JsonConvert.DeserializeObject<IEnumerable<Brand>>(result);
            }

            ViewData.Model = brand;

            return View();
        }
    }
}
