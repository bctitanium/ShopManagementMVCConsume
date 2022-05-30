using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume.Areas.Admin.Models;

namespace ShopManagementMVCConsume.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReceiptController : Controller
    {
        private readonly ILogger<ReceiptController> _logger;

        public ReceiptController(ILogger<ReceiptController> logger)
        {
            _logger = logger;
        }

        // GET: Admin/Receipt
        public async Task<IActionResult> Get()
        {
            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("Receipt");

            IEnumerable<Receipt> receipts = new List<Receipt>();

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                receipts = JsonConvert.DeserializeObject<IEnumerable<Receipt>>(result);
            }

            ViewData.Model = receipts;

            return View();
        }

        public async Task<IActionResult> Insert(Receipt receipt)
        {
            HttpResponseMessage response = await GloblaVariables.PostResponseAsync("Receipt", receipt);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Get", "Receipt");
            }

            return View();
        }
    }
}
