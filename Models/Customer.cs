namespace ShopManagementMVCConsume.Models
{
    public partial class Customer : User
    {
        public bool IsMembership { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; } = new HashSet<Receipt>();
    }
}
