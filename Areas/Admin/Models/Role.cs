using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ShopManagementMVCConsume.Areas.Admin.Models
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; } = new HashSet<UserRole>();
    }
}
