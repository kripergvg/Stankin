namespace StankinQuestionnaire.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Сalculation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CalculationType_ID = c.Long(),
                        Creator_Id = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CalculationTypes", t => t.CalculationType_ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id)
                .Index(t => t.CalculationType_ID)
                .Index(t => t.Creator_Id);
            
            CreateTable(
                "dbo.CalculationTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UnitName = c.String(),
                        Point = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateChanged = c.DateTime(nullable: false),
                        Indicator_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Indicators", t => t.Indicator_ID)
                .Index(t => t.Indicator_ID);
            
            CreateTable(
                "dbo.Indicators",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        MaxPoint = c.Int(nullable: false),
                        Comment = c.String(),
                        DateChanged = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        IndicatorGroup_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.IndicatorGroups", t => t.IndicatorGroup_ID)
                .Index(t => t.IndicatorGroup_ID);
            
            CreateTable(
                "dbo.IndicatorGroups",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Weight = c.Double(nullable: false),
                        DateChanged = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DocumentType_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentType_ID)
                .Index(t => t.DocumentType_ID);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        MaxPoint = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateChanged = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Creator_Id = c.Long(),
                        DocumentType_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.Creator_Id)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentType_ID)
                .Index(t => t.Creator_Id)
                .Index(t => t.DocumentType_ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Сalculation", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Indicators", "IndicatorGroup_ID", "dbo.IndicatorGroups");
            DropForeignKey("dbo.IndicatorGroups", "DocumentType_ID", "dbo.DocumentTypes");
            DropForeignKey("dbo.Documents", "DocumentType_ID", "dbo.DocumentTypes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documents", "Creator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CalculationTypes", "Indicator_ID", "dbo.Indicators");
            DropForeignKey("dbo.Сalculation", "CalculationType_ID", "dbo.CalculationTypes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Documents", new[] { "DocumentType_ID" });
            DropIndex("dbo.Documents", new[] { "Creator_Id" });
            DropIndex("dbo.IndicatorGroups", new[] { "DocumentType_ID" });
            DropIndex("dbo.Indicators", new[] { "IndicatorGroup_ID" });
            DropIndex("dbo.CalculationTypes", new[] { "Indicator_ID" });
            DropIndex("dbo.Сalculation", new[] { "Creator_Id" });
            DropIndex("dbo.Сalculation", new[] { "CalculationType_ID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Documents");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.IndicatorGroups");
            DropTable("dbo.Indicators");
            DropTable("dbo.CalculationTypes");
            DropTable("dbo.Сalculation");
        }
    }
}
