using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopManagementMVCConsume.Models;

namespace ShopManagementMVCConsume.Controllers
{
    public class ReceiptController : Controller
    {
        public async Task<IActionResult> Get()
        {
            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("DetailedReceipt");

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
