namespace ShopManagementMVCConsume.Models
{
    public partial class Product
    {
        public int      Id                  { get; set; }
        public int      StoreId             { get; set; }
        public string   ProductName         { get; set; } = string.Empty;
        public string?  ProductDescription  { get; set; }
        public double?  BuyPrice            { get; set; }
        public double   SellPrice           { get; set; }
        public int      Quantity            { get; set; }
        public string?  ImageFile           { get; set; }
        public string?  BrandName           { get; set; }
        public string?  CountryCode         { get; set; }
        public string?  CategoryName        { get; set; }
        public string?  CategoryDescription { get; set; }
        public string?  Gender              { get; set; }
        public string?  SizeCode            { get; set; }
        public int      SizeValue           { get; set; }
        public string?  Season              { get; set; }
        public string?  Weather             { get; set; }
        public string?  MainMaterial        { get; set; }

        public virtual Store? Store { get; set; }
        public virtual ICollection<DetailedReceipt> DetailedReceipts { get; set; } = new HashSet<DetailedReceipt>();
        public virtual ICollection<SupplyProduct> SupplyProducts { get; set; } = new HashSet<SupplyProduct>();
    }
}
