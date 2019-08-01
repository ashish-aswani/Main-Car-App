namespace CarServiceAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditValidation : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            //AlterColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            //AlterColumn("dbo.AspNetUsers", "Email", c => c.String(nullable: false, maxLength: 256));
            //AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "FirstName", c => c.String());
        }
    }
}
