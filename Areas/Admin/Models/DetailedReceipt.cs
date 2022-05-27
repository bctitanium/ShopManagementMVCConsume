using System;
using System.Collections.Generic;

namespace ShopManagementMVCConsume.Areas.Admin.Models
{
    public partial class DetailedReceipt
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ReceiptId { get; set; }
        public int Quantity { get; set; }

        public virtual Product? Products { get; set; }
        public virtual Receipt? Receipts { get; set; }
    }
}
