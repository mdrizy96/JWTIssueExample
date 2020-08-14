﻿using DataLayer.EfCode;
using FeatureAuthorize;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthorizeSetup
{
    /// <summary>
    /// This version provides:
    /// - Adds Permissions to the user's claims.
    /// </summary>
    // Thanks to https://korzh.com/blogs/net-tricks/aspnet-identity-store-user-data-in-claims
    public class AddPermissionsToUserClaims : UserClaimsPrincipalFactory<IdentityUser>
    {
        private readonly MyDbContext _extraAuthDbContext;

        public AddPermissionsToUserClaims(UserManager<IdentityUser> userManager, IOptions<IdentityOptions> optionsAccessor,
            MyDbContext extraAuthDbContext)
            : base(userManager, optionsAccessor)
        {
            _extraAuthDbContext = extraAuthDbContext;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            var userId = identity.Claims.GetUserIdFromClaims();
            var rtoPCalcer = new CalcAllowedPermissions(_extraAuthDbContext);
            identity.AddClaim(new Claim(PermissionConstants.PackedPermissionClaimType, await rtoPCalcer.CalcPermissionsForUserAsync(userId)));
            return identity;
        }
    }
}