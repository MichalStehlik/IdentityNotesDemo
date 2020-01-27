using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityNotesDemo.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "ADMIN", Name = "Administrátor" });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "USER", Name = "Uživatel" });
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "ADMINUSER",
                FirstName = "Main",
                LastName = "Administrator",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "michal.stehlik@pslib.cz",
                NormalizedEmail = "MICHAL.STEHLIK@PSLIB.CZ",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = string.Empty,
                PasswordHash = hasher.HashPassword(null,"Admin.1234")
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> { RoleId="ADMIN", UserId="ADMINUSER"});
        }
    }
}
