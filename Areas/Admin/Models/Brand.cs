namespace ShopManagementMVCConsume.Areas.Admin.Models
{
    public partial class Brand
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? BrandName { get; set; }
        public string? CountryCode { get; set; }

        public virtual Product? Product { get; set; }
    }
}
