namespace CarServiceAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationUserForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Cars", new[] { "CustomerId" });
            AddColumn("dbo.Cars", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cars", "ApplicationUserId");
            AddForeignKey("dbo.Cars", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Cars", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cars", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Cars", new[] { "ApplicationUserId" });
            DropColumn("dbo.Cars", "ApplicationUserId");
            CreateIndex("dbo.Cars", "CustomerId");
            AddForeignKey("dbo.Cars", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
