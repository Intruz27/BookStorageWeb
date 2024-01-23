using BookStorageWeb.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStorageWeb.Data
{
    public class AuthDbContext: IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            
            base.OnModelCreating(builder);

            //
            var superAdminRoleId = "b0634bf9-dee5-459f-ba55-54ff472803ee";
            var adminRoleId = "d5307b02-2486-430f-bb9f-8a6fe2cd5a0c";
            var userRoleId = "b090814d-2403-4853-be32-efeab18f31cf";

            var roles = new List<IdentityRole>
            {
                new IdentityRole() {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole() {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole() {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            //Seed Super admin

            var superAdminId = "b0634bf9-dee5-459f-ba55-54ff472803ee";
            var superAdminUser = new IdentityUser()
            {
                Id = superAdminId,
                UserName = "superadmin@bookStorageWeb.com",
                Email = "superadmin@bookStorageWeb.com",
                NormalizedEmail = "superadmin@bookStorageWeb.com".ToUpper(),
                NormalizedUserName = "superadmin@bookStorageWeb.com".ToUpper()
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                                    .HashPassword(superAdminUser, "superadmin123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);


            //Add all roles to superAdmin
            var superAdminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                },
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

        }
    }

   
}
