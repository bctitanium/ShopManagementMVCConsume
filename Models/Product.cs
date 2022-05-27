namespace ShopManagementMVCConsume.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double BuyPrice { get; set; }
        public double SellPrice { get; set; }
        public int Quantity { get; set; }
        public string? ImageFile { get; set; }

        public virtual Store? Store { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<DetailedReceipt> DetailedReceipts { get; set; } = new HashSet<DetailedReceipt>();
        public virtual ICollection<SupplyProduct> SupplyProducts { get; set; } = new HashSet<SupplyProduct>();
    }
}
