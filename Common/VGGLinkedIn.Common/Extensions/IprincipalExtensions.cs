namespace VGGLinkedIn.Common.Extensions
{
    using System.Security.Principal;

    using VGGLinkedIn.Common.Constants;

    public static class IPrincipalExtensions
    {
        public static bool IsLoggedIn(this IPrincipal principal)
        {
            return principal != null && principal.Identity.IsAuthenticated;
        }

        public static bool IsAdmin(this IPrincipal principal)
        {
            return principal != null && principal.IsInRole(GlobalConstants.RoleNameAdministrator);
        }
    }
}
