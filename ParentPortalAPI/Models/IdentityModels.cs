using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace ParentPortalAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleID { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext { 
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /// <summary>
        /// Sets standard Identity table properties to match ParentPortalAPI's schema
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("Accounts");
            modelBuilder.Entity<IdentityUserRole>().ToTable("AccountRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("AccountLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("AccountClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");


        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }

    public class ApplicationUserClaim : IdentityUserClaim { }

    public class ApplicationUserLogin : IdentityUserLogin { }

    public class ApplicationUserRole : IdentityUserRole
    {
    }

    public class ApplicationRole : IdentityRole
    {
    }
}