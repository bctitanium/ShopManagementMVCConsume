using System;
using System.ComponentModel.DataAnnotations;

namespace ShopManagementMVCConsume.Models
{
    public class ErrorViewModel
    {
        [Required]
        public string RequestId { get; set; } = null!;

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
