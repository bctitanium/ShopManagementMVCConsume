namespace ShopManagementMVCConsume.Models
{
    public partial class SupplyProduct
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime ArrivesAt { get; set; }
        public bool IsArrived { get; set; }

        public virtual Product? Product { get; set; }
        public virtual Supplier? Supplier { get; set; }
    }
}
