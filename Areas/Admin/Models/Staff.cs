namespace ShopManagementMVCConsume.Areas.Admin.Models
{
    public partial class Staff : User
    {

        public int StoreId { get; set; }
        public bool IsHead { get; set; }

        public virtual User? IdNavigation { get; set; }
        public virtual Store? Store { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; } = new HashSet<Receipt>();
    }
}
