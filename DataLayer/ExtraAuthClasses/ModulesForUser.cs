using DataLayer.ExtraAuthClasses.Support;
using PermissionParts;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.ExtraAuthClasses
{
    /// <summary>
    /// This holds what modules a user or tenant has
    /// </summary>
    public class ModulesForUser : IChangeEffectsUser, IAddRemoveEffectsUser
    {
        /// <summary>
        /// This links modules to a user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="allowedPaidForModules"></param>
        public ModulesForUser(string userId, PaidForModules allowedPaidForModules)
        {
            UserId = userId ?? throw new ArgumentNullException(nameof(userId));
            AllowedPaidForModules = allowedPaidForModules;
        }

        [Key]
        [MaxLength(ExtraAuthConstants.UserIdSize)]
        public string UserId { get; private set; }

        public PaidForModules AllowedPaidForModules { get; private set; }
    }
}