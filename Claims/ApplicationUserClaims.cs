using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Pramerica_Assignment.Models;
using System.Security.Claims;

namespace Pramerica_Assignment.Claims
{
    public class ApplicationUserClaims : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaims(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserName", user.Name ?? ""));
            identity.AddClaim(new Claim("UserEmail", user.Email ?? ""));

            return identity;
        }
    }
}
