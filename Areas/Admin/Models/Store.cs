namespace ShopManagementMVCConsume.Areas.Admin.Models
{
    public partial class Store
    {
        public int Id { get; set; }
        public string? StoreName { get; set; }
        public string? StoreAddress { get; set; }
        public string? StorePhone { get; set; }
        public string? Logo { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public virtual ICollection<Staff> Staff { get; set; } = new HashSet<Staff>();
    }
}
