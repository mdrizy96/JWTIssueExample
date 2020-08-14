using DataLayer.EfCode.Configurations;
using DataLayer.ExtraAuthClasses;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EfCode
{
    public class MyDbContext : DbContext
    {
        public DbSet<UserToRole> UserToRoles { get; set; }
        public DbSet<RoleToPermissions> RolesToPermissions { get; set; }
        public DbSet<ModulesForUser> ModulesForUsers { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ExtraAuthorizeConfig();
        }
    }
}