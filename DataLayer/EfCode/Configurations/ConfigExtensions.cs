using DataLayer.ExtraAuthClasses;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EfCode.Configurations
{
    public static class ConfigExtensions
    {
        public static void ExtraAuthorizeConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserToRole>().HasKey(x => new { x.UserId, x.RoleName });

            modelBuilder.Entity<RoleToPermissions>()
                .Property("_permissionsInRole")
                .HasColumnName("PermissionsInRole");
        }
    }
}