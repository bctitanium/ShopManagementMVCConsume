namespace ShopManagementMVCConsume.Areas.Admin.Models
{
    public partial class Receipt
    {

        public int Id { get; set; }
        public string? CustomerId { get; set; }
        public string? StaffId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public double ReceiptAmount { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Staff? Staff { get; set; }
        public virtual ICollection<DetailedReceipt> DetailedReceipts { get; set; } = new HashSet<DetailedReceipt>();
    }
}
