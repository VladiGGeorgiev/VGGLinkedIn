namespace VGGLinkedIn.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using VGGLinkedIn.Data.Migrations;
    using VGGLinkedIn.Data.Models;

    public class VggLinkedInDbContext : IdentityDbContext<User>, IVggLinkedInDbContext
    {
        public VggLinkedInDbContext()
            : base("VGGLinkedInDbConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VggLinkedInDbContext, Configuration>());
        }

        public static VggLinkedInDbContext Create()
        {
            return new VggLinkedInDbContext();
        }

        public IDbSet<Certification> Certifications { get; set; }

        public IDbSet<Discussion> Discussions { get; set; }

        public IDbSet<Experience> Experiences { get; set; }

        public IDbSet<Group> Groups { get; set; }

        public IDbSet<UserLanguage> Languages { get; set; }

        public IDbSet<Project> Projects { get; set; }

        public IDbSet<Skill> Skills { get; set; }

        public IDbSet<Endorcement> Endorcements { get; set; }

        public IDbSet<AdministrationLog> AdministrationLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasRequired(x => x.Owner)
                .WithOptional()
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Endorcement>()
                .HasRequired(x => x.UserSkill)
                .WithMany(x => x.Endorcements)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Experience>()
                .HasRequired(x => x.User)
                .WithMany(x => x.Experiences)
                .WillCascadeOnDelete(false);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
