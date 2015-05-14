namespace VGGLinkedIn.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Certifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LicenseNumber = c.String(),
                        Url = c.String(),
                        TakenDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Discussions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Details = c.String(),
                        Group_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Type = c.Int(nullable: false),
                        OwnerId = c.String(nullable: false, maxLength: 128),
                        Website = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        AvatarUrl = c.String(),
                        Summary = c.String(),
                        ContactInfo_Phone = c.String(),
                        ContactInfo_Twitter = c.String(),
                        ContactInfo_Website = c.String(),
                        ContactInfo_Facebook = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        UserSkill_Id = c.Int(),
                        Group_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserSkills", t => t.UserSkill_Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.UserSkill_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CompanyName = c.String(),
                        Location = c.String(),
                        HireDate = c.DateTime(nullable: false),
                        LeavingDate = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        Url = c.String(),
                        OccupationExperience_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Experiences", t => t.OccupationExperience_Id)
                .Index(t => t.OccupationExperience_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        SkillId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.UserId)
                .Index(t => t.SkillId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ProjectUsers",
                c => new
                    {
                        Project_Id = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Project_Id, t.User_Id })
                .ForeignKey("dbo.Projects", t => t.Project_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Project_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Groups", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.UserSkills", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSkills", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.AspNetUsers", "UserSkill_Id", "dbo.UserSkills");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectUsers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectUsers", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Projects", "OccupationExperience_Id", "dbo.Experiences");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserLanguages", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Groups", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Experiences", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Certifications", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Discussions", "Group_Id", "dbo.Groups");
            DropIndex("dbo.ProjectUsers", new[] { "User_Id" });
            DropIndex("dbo.ProjectUsers", new[] { "Project_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.UserSkills", new[] { "User_Id" });
            DropIndex("dbo.UserSkills", new[] { "SkillId" });
            DropIndex("dbo.UserSkills", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Projects", new[] { "OccupationExperience_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.UserLanguages", new[] { "User_Id" });
            DropIndex("dbo.Experiences", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Group_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "UserSkill_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Groups", new[] { "User_Id" });
            DropIndex("dbo.Groups", new[] { "OwnerId" });
            DropIndex("dbo.Discussions", new[] { "Group_Id" });
            DropIndex("dbo.Certifications", new[] { "User_Id" });
            DropTable("dbo.ProjectUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Skills");
            DropTable("dbo.UserSkills");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Projects");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.UserLanguages");
            DropTable("dbo.Experiences");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Groups");
            DropTable("dbo.Discussions");
            DropTable("dbo.Certifications");
        }
    }
}
