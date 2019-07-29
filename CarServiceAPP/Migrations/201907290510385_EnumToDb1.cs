namespace CarServiceAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumToDb1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Make", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Style", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "ServiceType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "ServiceType", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Style", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Make", c => c.Int(nullable: false));
        }
    }
}
