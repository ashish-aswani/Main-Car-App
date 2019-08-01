namespace CarServiceAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Latest : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.AspNetUsers", "City", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "City", c => c.String());
        }
    }
}
