using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume.Areas.Admin.Models;

namespace ShopManagementMVCConsume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplyProductController : Controller
    {
        private readonly ILogger<SupplyProductController> _logger;

        public SupplyProductController(ILogger<SupplyProductController> logger)
        {
            _logger = logger;
        }

        // GET: Admin/SupplyProduct
        public async Task<IActionResult> Get()
        {
            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("SupplyProduct");

            IEnumerable<SupplyProduct> supplyProducts = new List<SupplyProduct>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                supplyProducts = JsonConvert.DeserializeObject<IEnumerable<SupplyProduct>>(result);
            }

            ViewData.Model = supplyProducts;

            return View();
        }

        public async Task<IActionResult> Insert(SupplyProduct supplyProduct)
        {
            HttpResponseMessage response = await GloblaVariables.PostResponseAsync("SupplyProduct", supplyProduct);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Get", "SupplyProduct");
            }

            return View();
        }
    }
}
