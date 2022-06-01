using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume.Models;
using X.PagedList;

namespace ShopManagementMVCConsume.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Get(int? page)
        {
            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("Product");

            IEnumerable<Product> products = new List<Product>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
            }
            ViewData.Model = products;
            var pageNumber = page ?? 1;
            ViewBag.products = products.ToList().ToPagedList(pageNumber, 1);
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("Product");

            IEnumerable<Product> products = new List<Product>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
            }

            ViewData.Model = products;

            var data = products.FirstOrDefault(x => x.Id == id);

            if(products == null)
            {
                return RedirectToAction("Get");
            }

            return View(data);
        }
    }
}
