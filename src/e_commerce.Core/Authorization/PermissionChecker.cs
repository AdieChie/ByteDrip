using Abp.Authorization;
using e_commerce.Authorization.Roles;
using e_commerce.Authorization.Users;

namespace e_commerce.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
