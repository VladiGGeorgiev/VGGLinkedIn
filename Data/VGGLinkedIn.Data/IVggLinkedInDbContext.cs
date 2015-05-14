namespace VGGLinkedIn.Data
{
    using System.Data.Entity;

    using VGGLinkedIn.Data.Models;

    public interface IVggLinkedInDbContext
    {
        IDbSet<Certification> Certifications { get; set; }

        IDbSet<Discussion> Discussions { get; set; }

        IDbSet<Experience> Experiences { get; set; }

        IDbSet<Group> Groups { get; set; }

        IDbSet<UserLanguage> Languages { get; set; }

        IDbSet<Project> Projects { get; set; }

        IDbSet<Skill> Skills { get; set; }

        IDbSet<Endorcement> Endorcements { get; set; }

        IDbSet<AdministrationLog> AdministrationLogs { get; set; } 

        int SaveChanges();
    }
}
