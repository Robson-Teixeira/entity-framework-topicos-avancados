namespace P3.Migrations
{
    using System.Data.Entity.Migrations;

    /*Gerado por meio do Package Manager Console: PM> Enable-Migrations*/
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalInfoDefinition",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Description = c.String(nullable: false, maxLength: 1024),
                    IsActive = c.Boolean(nullable: false),
                    LastUpdateDate = c.DateTime(nullable: false),
                    LastUpdateUser = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AdditionalInfo",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Description = c.String(nullable: false, maxLength: 1024),
                    AddressId = c.Guid(nullable: false),
                    AdditionalInfoDefinitionId = c.Guid(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    LastUpdateDate = c.DateTime(nullable: false),
                    LastUpdateUser = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdditionalInfoDefinition", t => t.AdditionalInfoDefinitionId)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .Index(t => t.AddressId)
                .Index(t => t.AdditionalInfoDefinitionId);

            CreateTable(
                "dbo.Address",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Street = c.String(nullable: false, maxLength: 500),
                    Number = c.String(nullable: false, maxLength: 10),
                    District = c.String(nullable: false, maxLength: 50),
                    City = c.String(nullable: false, maxLength: 50),
                    State = c.String(nullable: false, maxLength: 50),
                    Country = c.String(nullable: false, maxLength: 100),
                    PersonId = c.Guid(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    LastUpdateDate = c.DateTime(nullable: false),
                    LastUpdateUser = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId);

            CreateTable(
                "dbo.Person",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 60),
                    FranchiseId = c.Guid(nullable: false),
                    UserId = c.Guid(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    LastUpdateDate = c.DateTime(nullable: false),
                    LastUpdateUser = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Franchise", t => t.FranchiseId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.FranchiseId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Franchise",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 60),
                    OrganizationId = c.Guid(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    LastUpdateDate = c.DateTime(nullable: false),
                    LastUpdateUser = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);

            CreateTable(
                "dbo.Organization",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 60),
                    EmailId = c.Guid(nullable: false),
                    Image = c.String(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    LastUpdateDate = c.DateTime(nullable: false),
                    LastUpdateUser = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Email", t => t.EmailId)
                .Index(t => t.EmailId);

            CreateTable(
                "dbo.Email",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Domain = c.String(nullable: false, maxLength: 50),
                    IsActive = c.Boolean(nullable: false),
                    LastUpdateDate = c.DateTime(nullable: false),
                    LastUpdateUser = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Phone",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Ddi = c.Int(nullable: false),
                    Ddd = c.Int(nullable: false),
                    Number = c.Int(nullable: false),
                    PersonId = c.Guid(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    LastUpdateDate = c.DateTime(nullable: false),
                    LastUpdateUser = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .Index(t => t.PersonId);

            CreateTable(
                "dbo.User",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 20),
                    EmailId = c.Guid(nullable: false),
                    Password = c.String(nullable: false, maxLength: 20),
                    LastUpdateDate = c.DateTime(nullable: false),
                    LastUpdateUser = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Email", t => t.EmailId)
                .Index(t => t.EmailId);

            CreateTable(
                "dbo.Role",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 60),
                    Tag = c.String(nullable: false, maxLength: 30),
                    Description = c.String(nullable: false, maxLength: 1024),
                    ConfigurationId = c.Guid(nullable: false),
                    IsActive = c.Boolean(nullable: false),
                    LastUpdateDate = c.DateTime(nullable: false),
                    LastUpdateUser = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Configuration", t => t.ConfigurationId)
                .Index(t => t.ConfigurationId);

            CreateTable(
                "dbo.Configuration",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Description = c.String(nullable: false, maxLength: 1024),
                    IsActive = c.Boolean(nullable: false),
                    LastUpdateDate = c.DateTime(nullable: false),
                    LastUpdateUser = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.UserRoles",
                c => new
                {
                    RoleId = c.Guid(nullable: false),
                    UserId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Person", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Role", "ConfigurationId", "dbo.Configuration");
            DropForeignKey("dbo.User", "EmailId", "dbo.Email");
            DropForeignKey("dbo.Phone", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Person", "FranchiseId", "dbo.Franchise");
            DropForeignKey("dbo.Franchise", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.Organization", "EmailId", "dbo.Email");
            DropForeignKey("dbo.Address", "PersonId", "dbo.Person");
            DropForeignKey("dbo.AdditionalInfo", "AddressId", "dbo.Address");
            DropForeignKey("dbo.AdditionalInfo", "AdditionalInfoDefinitionId", "dbo.AdditionalInfoDefinition");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.Role", new[] { "ConfigurationId" });
            DropIndex("dbo.User", new[] { "EmailId" });
            DropIndex("dbo.Phone", new[] { "PersonId" });
            DropIndex("dbo.Organization", new[] { "EmailId" });
            DropIndex("dbo.Franchise", new[] { "OrganizationId" });
            DropIndex("dbo.Person", new[] { "UserId" });
            DropIndex("dbo.Person", new[] { "FranchiseId" });
            DropIndex("dbo.Address", new[] { "PersonId" });
            DropIndex("dbo.AdditionalInfo", new[] { "AdditionalInfoDefinitionId" });
            DropIndex("dbo.AdditionalInfo", new[] { "AddressId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Configuration");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Phone");
            DropTable("dbo.Email");
            DropTable("dbo.Organization");
            DropTable("dbo.Franchise");
            DropTable("dbo.Person");
            DropTable("dbo.Address");
            DropTable("dbo.AdditionalInfo");
            DropTable("dbo.AdditionalInfoDefinition");
        }
    }
}