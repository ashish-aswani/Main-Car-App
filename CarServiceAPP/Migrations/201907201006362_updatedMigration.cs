namespace CarServiceAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Mobile", c => c.Long(nullable: false));
            DropColumn("dbo.Customers", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Phone", c => c.Long(nullable: false));
            DropColumn("dbo.Customers", "Mobile");
        }
    }
}
