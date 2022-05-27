namespace ShopManagementMVCConsume.Models
{
    public partial class Supplier
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string? SupplierName { get; set; }

        public virtual ICollection<SupplyProduct> SupplyProducts { get; set; } = new HashSet<SupplyProduct>();
    }
}
