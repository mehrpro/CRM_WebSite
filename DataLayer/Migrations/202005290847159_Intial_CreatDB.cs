namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial_CreatDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleModels",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Role = c.String(maxLength: 100),
                        Enabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.UsersModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false, maxLength: 100),
                        LName = c.String(nullable: false, maxLength: 100),
                        FullName = c.String(maxLength: 200),
                        AddressOne = c.String(nullable: false, maxLength: 350),
                        AddressTwo = c.String(maxLength: 350),
                        PhoneNumber = c.String(maxLength: 20),
                        Mobile = c.String(nullable: false, maxLength: 20),
                        FaxNumber = c.String(maxLength: 20),
                        CompanyName = c.String(nullable: false, maxLength: 200),
                        DateTimeRegister = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 200),
                        WebSite = c.String(maxLength: 250),
                        RoleID = c.Int(nullable: false),
                        EnableUser = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RoleModels", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersModels", "RoleID", "dbo.RoleModels");
            DropIndex("dbo.UsersModels", new[] { "RoleID" });
            DropTable("dbo.UsersModels");
            DropTable("dbo.RoleModels");
        }
    }
}
