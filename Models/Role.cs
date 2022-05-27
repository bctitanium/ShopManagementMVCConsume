using Microsoft.AspNetCore.Identity;

namespace ShopManagementMVCConsume.Models
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; } = new HashSet<UserRole>();
    }
}
