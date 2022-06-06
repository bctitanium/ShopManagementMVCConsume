using ShopManagementMVCConsume.Models;

namespace ShopManagementMVCConsume.ViewModel
{
    public class Cart
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        //public int CustomerId { get; set; }
        public int Quantity { get; set; }
    }
}
