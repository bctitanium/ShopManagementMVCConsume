using Microsoft.AspNetCore.Identity;

namespace ShopManagementMVCConsume.Models
{
    public partial class UserRole : IdentityUserRole<string>
    {
        public virtual Role? Role { get; set; }
        public virtual User? User { get; set; }
    }
}
