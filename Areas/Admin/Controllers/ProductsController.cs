using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume;
using ShopManagementMVCConsume.Areas.Admin.Models;

namespace Shoppppp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Get()
        {
            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("Product");

            IEnumerable<Product> products = new List<Product>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
            }

            ViewData.Model = products;

            return View();
        }

        public async Task<IActionResult> Insert(Product product)
        {
            HttpResponseMessage response = await GloblaVariables.PostResponseAsync("Product", product);
            

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Get", "Products");
            }

            return View();
        }
      
    }
}
