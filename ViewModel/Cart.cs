using ShopManagementMVCConsume.Models;

namespace ShopManagementMVCConsume.ViewModel
{
    public class Cart
    {
        public Product? product { get; set; }
        public int amount { get; set; }
        public double TotalMonney => amount * product.SellPrice;
    }
}
