using System;
using System.ComponentModel.DataAnnotations;

namespace ShopManagementMVCConsume.Areas.Admin.Models
{
    public class ErrorViewModel
    {
        [Required]
        public string RequestId { get; set; } = null!;

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
