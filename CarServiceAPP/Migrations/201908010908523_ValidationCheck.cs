namespace CarServiceAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationCheck : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Mobile = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
