using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume.Areas.Admin.Models;

namespace ShopManagementMVCConsume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupplierController : Controller
    {
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(ILogger<SupplierController> logger)
        {
            _logger = logger;
        }

        // GET: Admin/Supplier
        public async Task<IActionResult> Get()
        {
            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("Supplier");

            IEnumerable<Supplier> suppliers = new List<Supplier>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                suppliers = JsonConvert.DeserializeObject<IEnumerable<Supplier>>(result);
            }

            ViewData.Model = suppliers;

            return View();
        }

        public async Task<IActionResult> Insert(Supplier supplier)
        {
            HttpResponseMessage response = await GloblaVariables.PostResponseAsync("Supplier", supplier);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Get", "Supplier");
            }

            return View();
        }
    }
}
