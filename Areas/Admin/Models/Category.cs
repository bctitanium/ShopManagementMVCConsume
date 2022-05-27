using System;
using System.Collections.Generic;

namespace ShopManagementMVCConsume.Areas.Admin.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public string? Gender { get; set; }
        public string? SizeCode { get; set; }
        public int SizeValue { get; set; }
        public string? Season { get; set; }
        public string? Weather { get; set; }
        public string? MainMaterial { get; set; }

        public virtual Product? Product { get; set; }
    }
}
