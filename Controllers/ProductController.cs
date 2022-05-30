using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume.Models;
using PagedList;

namespace ShopManagementMVCConsume.Controllers
{
    public class ProductController : Controller
    {
       
        public async Task<IActionResult> Get(int? page, int? pagesize)
        {
            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("Product");

            IEnumerable<Product> products = new List<Product>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
            }
          
            ViewData.Model = products;

            if (page == null)
            {
                page = 1;
            }
            if (pagesize == null)
            {
                pagesize = 10;
            }

            var product = products.ToList();

            return View(product.ToPagedList((int)page, (int)pagesize));
        }

        public IActionResult Details(int id)
        {

            return View();
        }
   
    }
}
