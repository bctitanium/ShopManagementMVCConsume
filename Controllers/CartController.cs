//using AspNetCoreHero.ToastNotification.Abstractions;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using ShopManagementMVCConsume.Models;
//using ShopManagementMVCConsume.ViewModel;

//namespace ShopManagementMVCConsume.Controllers
//{
//    public class CartController : Controller
//    {
//        public INotyfService _notyfService { get; }
//        public CartController(INotyfService notyfService)
//        {
//            _notyfService = notyfService;
//        }

//        public List<Cart> GioHang
//        {
//            get
//            {
//                var gh = HttpContext.Session.Get<List<Cart>>("GioHang");
//                if (gh == default(List<Cart>))
//                {
//                    gh = new List<Cart>();
//                }
//                return gh;
//            }
//        }

//        [Route("api/cart/add")]
//        public async Task<IActionResult> AddtoCart(int productID, int? amount)
//        {
//            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("Product");

//            IEnumerable<Product> products = new List<Product>();

//            if (response.IsSuccessStatusCode)
//            {
//                string result = response.Content.ReadAsStringAsync().Result;
//                products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
//            }
//            ViewData.Model = products;
//            List<Cart> giohang = GioHang;
//            try
//            {
//                Cart item = GioHang.SingleOrDefault(p => p.product.Id == productID);
//                if (item != null)
//                {
//                    if (amount.HasValue)
//                    {
//                        item.amount = amount.Value;
//                    }
//                    else
//                    {
//                        item.amount++;
//                    }
//                }
//                else
//                {
//                    Product hh = products.SingleOrDefault(p => p.Id == productID);
//                    item = new Cart
//                    {
//                        amount = amount.HasValue ? amount.Value : 1,
//                        product = hh
//                    };
//                    giohang.Add(item);

//                }
//                HttpContext.Session.Set<List<Cart>>("GioHang", giohang);
//                _notyfService.Success("Them gio hang thanh cong");
//                return Json(new { success = true });
//            }
//            catch
//            {

//            }

//            return View();
//        }

//        [Route("api/cart/update")]
//        public async Task<IActionResult> UpdatetoCart(int productID, int? amount)
//        {
//            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("Product");

//            IEnumerable<Product> products = new List<Product>();

//            if (response.IsSuccessStatusCode)
//            {
//                string result = response.Content.ReadAsStringAsync().Result;
//                products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
//            }
//            ViewData.Model = products;
//            var cart = HttpContext.Session.Get<List<Cart>>("GioHang");
//            try
//            {
//                if (cart != null)
//                {
//                    Cart item = cart.SingleOrDefault(p => p.product.Id == productID);
//                    if (item != null && amount.HasValue)
//                    {
//                        item.amount = amount.Value;
//                    }
//                    HttpContext.Session.Set<List<Cart>>("GioHang", cart);

//                }
//                return Json(new { success = true });
//            }
//            catch
//            {
//                return Json(new { success = false });
//            }
//        }

//        [Route("api/cart/remove")]
//        public async Task<IActionResult> RemovetoCart(int productID, int? amount)
//        {
//            HttpResponseMessage response = await GloblaVariables.GetResponseAsync("Product");

//            IEnumerable<Product> products = new List<Product>();

//            if (response.IsSuccessStatusCode)
//            {
//                string result = response.Content.ReadAsStringAsync().Result;
//                products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
//            }
//            ViewData.Model = products;
//            try
//            {
//                List<Cart> giohang = GioHang;
//                Cart item = GioHang.SingleOrDefault(p => p.product.Id == productID);
//                if (item != null)
//                {
//                    giohang.Remove(item);
//                }
//                HttpContext.Session.Set<List<Cart>>("GioHang", giohang);
//                return Json(new { success = true });
//            }
//            catch
//            {
//                return Json(new { success = false });
//            }

//        }
//        [Route("cart.html", Name = "Cart")]
//        public async Task<IActionResult> Index()
//        {
//            return View(GioHang);
//        }
//    }
//}
