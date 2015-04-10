namespace Mvc_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Link = c.String(),
                        Raiting = c.Double(nullable: false),
                        AddDate = c.String(),
                        Description = c.String(),
                        ShortDescription = c.String(),
                        User_Id = c.Int(),
                        UserBase_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.UserProfile", t => t.UserBase_UserId)
                .Index(t => t.User_Id)
                .Index(t => t.UserBase_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Links", new[] { "UserBase_UserId" });
            DropIndex("dbo.Links", new[] { "User_Id" });
            DropForeignKey("dbo.Links", "UserBase_UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Links", "User_Id", "dbo.Users");
            DropTable("dbo.UserProfile");
            DropTable("dbo.Users");
            DropTable("dbo.Links");
        }
    }
}
