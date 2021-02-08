using Kiddywee.BLL.Core;
using Kiddywee.DAL.Data;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kiddywee.Core
{
    public class CustomClaims : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        private readonly ApplicationDbContext _ctx;
        
        public CustomClaims(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options, ApplicationDbContext ctx) : base(userManager, roleManager, options)
        {
            _ctx = ctx;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            if (!await UserManager.IsInRoleAsync(user, Constants.ROLE_GLOBALADMIN))
            {
                var person = await _ctx.People
                    .FirstAsync(p => p.Id == user.PersonId);

                identity.AddClaim(new Claim(Constants.CLAIM_ORGANIZATIONID, person.OrganizationId.ToString()));
                identity.AddClaim(new Claim(Constants.CLAIM_PEROSONID, person.Id.ToString()));

            }

            identity.AddClaim(new Claim(Constants.CLAIM_PEROSONID, user.PersonId.ToString()));

            return identity;
        }
    }
}
