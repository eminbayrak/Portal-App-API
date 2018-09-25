using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ParentPortalAPI.Models
{
    public class Account : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Account> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here            
            userIdentity.AddClaim(new Claim("TeamName", TeamName.ToString()));
            return userIdentity;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeamName { get; set; }
        public ICollection<AccountGroup> AccountGroups { get; set; }
        public ICollection<AccountStudent> AccountStudents { get; set; }
        public ICollection<AccountEvent> AccountEvents { get; set; }
    }
    public static class IdentityExtensions
    {
        public static string GetTeamName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("TeamName");
            //return (claim != null) ? claim.Value : string.Empty;
            return claim.Value;
        }
    }
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext() : base("DefaultConnection") { }

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
            modelBuilder.Entity<Account>()
                .ToTable("Account");
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Account");
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("AccountRole");
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("AccountLogin");
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("AccountClaim");
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Role");
            modelBuilder.Entity<Topic>()
                .ToTable("Topic");
            modelBuilder.Entity<Comment>()
                .ToTable("Comments");
            modelBuilder.Entity<District>()
                .ToTable("District");
            modelBuilder.Entity<Student>()
                .ToTable("Students");
            modelBuilder.Entity<Event>()
                .ToTable("Events");

            modelBuilder.Entity<AccountGroup>()
                .HasKey(ag => new { ag.AccountId, ag.GroupId });
            modelBuilder.Entity<AccountGroup>()
                .HasRequired(ag => ag.Account)
                .WithMany(g => g.AccountGroups)
                .HasForeignKey(ag => ag.AccountId);
            modelBuilder.Entity<AccountGroup>()
                .HasRequired(ag => ag.Group)
                .WithMany(a => a.AccountGroups)
                .HasForeignKey(ag => ag.GroupId);

            modelBuilder.Entity<AccountStudent>()
                .HasKey(acs => new { acs.AccountId, acs.StudentId });
            modelBuilder.Entity<AccountStudent>()
                .HasRequired(acs => acs.Account)
                .WithMany(s => s.AccountStudents)
                .HasForeignKey(acs => acs.AccountId);
            modelBuilder.Entity<AccountStudent>()
                .HasRequired(acs => acs.Student)
                .WithMany(a => a.AccountStudents)
                .HasForeignKey(acs => acs.StudentId);

            modelBuilder.Entity<AccountEvent>()
                .HasKey(ace => new { ace.AccountId, ace.EventId });
            modelBuilder.Entity<AccountEvent>()
                .HasRequired(ace => ace.Account)
                .WithMany(e => e.AccountEvents)
                .HasForeignKey(ace => ace.AccountId);
            modelBuilder.Entity<AccountEvent>()
                .HasRequired(ace => ace.Event)
                .WithMany(a => a.AccountEvents)
                .HasForeignKey(ace => ace.EventId);

            modelBuilder.Entity<TopicComment>()
                .HasKey(ct => new { ct.TopicId, ct.CommentId });
            modelBuilder.Entity<TopicComment>()
                .HasRequired(ct => ct.Topic)
                .WithMany(c => c.TopicComments)
                .HasForeignKey(ag => ag.CommentId);

            modelBuilder.Entity<DistrictGroup>()
                .HasKey(dg => new { dg.DistrictId, dg.GroupId });
            modelBuilder.Entity<DistrictGroup>()
                .HasRequired(dg => dg.District)
                .WithMany(g => g.DistrictGroups)
                .HasForeignKey(dg => dg.GroupId);

            modelBuilder.Entity<GroupEvent>()
                .HasKey(ge => new { ge.GroupId, ge.EventId });
            modelBuilder.Entity<GroupEvent>()
                .HasRequired(ge => ge.Group)
                .WithMany(e => e.GroupEvents)
                .HasForeignKey(ge => ge.GroupId);

            modelBuilder.Entity<GroupStudent>()
                .HasKey(gs => new { gs.GroupId, gs.StudentId });
            modelBuilder.Entity<GroupStudent>()
                .HasRequired(gs => gs.Group)
                .WithMany(s => s.GroupStudents)
                .HasForeignKey(gs => gs.GroupId);
            modelBuilder.Entity<GroupStudent>()
                .HasRequired(gs => gs.Student)
                .WithMany(s => s.GroupStudents)
                .HasForeignKey(gs => gs.StudentId);
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Student> Students { get; set; }

        public System.Data.Entity.DbSet<ParentPortalAPI.Models.AccountEvent> AccountEvents { get; set; }
    }

    public class ApplicationUserClaim : IdentityUserClaim { }

    public class ApplicationUserLogin : IdentityUserLogin { }

    public class ApplicationUserRole : IdentityUserRole { }

    public class ApplicationRole : IdentityRole<string, ApplicationUserRole> { }
}