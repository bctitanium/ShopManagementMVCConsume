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
            Product obj = new Product()
            {
                Id = product.Id,
                StoreId = product.StoreId,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                BuyPrice = product.BuyPrice,
                SellPrice = product.SellPrice,
                Quantity = product.Quantity,
                ImageFile = product.ImageFile
            };

            if (product.ProductName != null)
            {
                //HttpResponseMessage response = await GloblaVariables.ResponseAsync<Product>("Insert", product);

                using (var Client = new HttpClient())
                {
                    //HttpClient Client = new HttpClient();

                    Client.BaseAddress = new Uri("https://localhost:44355/api/");
                    Client.DefaultRequestHeaders.Accept.Clear();
                    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await Client.PostAsJsonAsync<Product>("Create", obj);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Get", "Products");
                    }
                }                
            }

            return View();
        }
    }
}
