namespace WebApi.RegisterInformation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Vin = c.String(),
                        Plaque = c.String(),
                        SubmitDateTime = c.DateTime(nullable: false),
                        Enable = c.Int(nullable: false),
                        Delete = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Family = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        PasswordConfirm = c.String(),
                        PasswordHash = c.String(),
                        SubmitDateTime = c.DateTime(nullable: false),
                        Enable = c.Int(nullable: false),
                        Delete = c.Int(nullable: false),
                        CountrySection_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountrySections", t => t.CountrySection_Id)
                .Index(t => t.CountrySection_Id);
            
            CreateTable(
                "dbo.CountrySections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.String(),
                        Section = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPermissions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Permission = c.String(),
                        SubmitDateTime = c.DateTime(nullable: false),
                        Enable = c.Int(nullable: false),
                        Delete = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarInfoes", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPermissions", "Id", "dbo.Users");
            DropForeignKey("dbo.Users", "CountrySection_Id", "dbo.CountrySections");
            DropIndex("dbo.UserPermissions", new[] { "Id" });
            DropIndex("dbo.Users", new[] { "CountrySection_Id" });
            DropIndex("dbo.CarInfoes", new[] { "UserId" });
            DropTable("dbo.UserPermissions");
            DropTable("dbo.CountrySections");
            DropTable("dbo.Users");
            DropTable("dbo.CarInfoes");
        }
    }
}
