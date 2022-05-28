using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume;
using ShopManagementMVCConsume.Areas.Admin.Models;
using System.Net.Http.Headers;

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
            HttpResponseMessage response = await GloblaVariables.ResponseAsync("Product");

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
            HttpClient Client = new HttpClient();

            Client.BaseAddress = new Uri("https://localhost:44355/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await Client.PostAsJsonAsync("api/Product", product);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Get", "Products");
            }

            return View();
        }
    }
}
