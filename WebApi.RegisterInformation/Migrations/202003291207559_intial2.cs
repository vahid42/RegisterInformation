namespace WebApi.RegisterInformation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserPermissions", new[] { "Id" });
            DropPrimaryKey("dbo.UserPermissions");
            AlterColumn("dbo.UserPermissions", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.UserPermissions", "Id");
            CreateIndex("dbo.UserPermissions", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserPermissions", new[] { "Id" });
            DropPrimaryKey("dbo.UserPermissions");
            AlterColumn("dbo.UserPermissions", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserPermissions", "Id");
            CreateIndex("dbo.UserPermissions", "Id");
        }
    }
}
