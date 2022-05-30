using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume.Areas.Admin.Models;

namespace ShopManagementMVCConsume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DetailedReceiptController : Controller
    {
        private readonly ILogger<DetailedReceiptController> _logger;

        public DetailedReceiptController(ILogger<DetailedReceiptController> logger)
        {
            _logger = logger;
        }

        // GET: Admin/DetailedReceipt
        public async Task<IActionResult> Get()
        {
            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("DetailedReceipt");

            IEnumerable<DetailedReceipt> detailedReceipts = new List<DetailedReceipt>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                detailedReceipts = JsonConvert.DeserializeObject<IEnumerable<DetailedReceipt>>(result);
            }

            ViewData.Model = detailedReceipts;

            return View();
        }

        public async Task<IActionResult> Insert(DetailedReceipt detailedReceipt)
        {
            HttpResponseMessage response = await GloblaVariables.PostResponseAsync("DetailedReceipt", detailedReceipt);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Get", "DetailedReceipt");
            }

            return View();
        }
    }
}
