using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog_managment_system.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var superAdminRoleId = "5364b205-18d1-48fa-afaf-73e967b3509a";
            var adminRoleId = "f1f1fde0-573b-4d8c-aa37-771c2a5ee45c";
            var userRoleId = "e0a4795d-1902-4c3e-8c17-4a90b51cd049";
            //seed the roles(User, Admin, Super Admin)
            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },

                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },

                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                },

            };
            builder.Entity<IdentityRole>().HasData(roles);
            //Seed Super Admin User
            var superAdminId = "0fc10fe8-0b04-43c6-90d4-a6611ecf5264";
            var superAdminUser = new IdentityUser()
            {
                Id = superAdminId,
                UserName = "superAdmin@BlogManSys.com",
                Email = "superAdmin@BlogManSys.com",
                NormalizedEmail = "superadmin@blogmansys.com".ToUpper(),
                NormalizedUserName = "superadmin@blogmansys.com".ToUpper()
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "superadmin123");
            builder.Entity<IdentityUser>().HasData(superAdminUser);
            //Add All Roles Top Super Admin User
            var superAdminRoles = new List<IdentityUserRole<string>>()
            {
               new IdentityUserRole <string>
               {
                RoleId = superAdminRoleId,
                UserId = superAdminId
               },
               new IdentityUserRole <string>
               {
                RoleId = adminRoleId,
                UserId = superAdminId
               },
               new IdentityUserRole <string>
               {
                RoleId = userRoleId,
                UserId = superAdminId
               },
            };
             builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }

    }
}
