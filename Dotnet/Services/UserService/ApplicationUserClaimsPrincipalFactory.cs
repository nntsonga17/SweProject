using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Web.Services.UserService
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ClanKlinike,IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ClanKlinike> userManager,
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            : base(userManager,roleManager,options)
            {}

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ClanKlinike user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("id", user.ID.ToString() ?? ""));
            identity.AddClaim(new Claim("role", user.Direktor.ToString() ?? ""));
            return identity;
        }
    }
}