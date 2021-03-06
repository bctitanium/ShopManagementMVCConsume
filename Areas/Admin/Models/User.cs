using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ShopManagementMVCConsume.Areas.Admin.Models
{
    public class User
    {
        public string id { get; set; } = string.Empty;
        public string Guid { get; set; } = System.Guid.NewGuid().ToString();
        public string FullName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? ProfileImage { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<UserRole> UserRoles { get; } = new HashSet<UserRole>();
    }
}
