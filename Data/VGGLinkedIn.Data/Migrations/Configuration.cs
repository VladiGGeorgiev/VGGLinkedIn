namespace VGGLinkedIn.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<VggLinkedInDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "VGGLinkedIn.Data.VggLinkedInDbContext";
        }

        protected override void Seed(VggLinkedInDbContext context)
        {
            // TODO: add data via seed
        }
    }
}
