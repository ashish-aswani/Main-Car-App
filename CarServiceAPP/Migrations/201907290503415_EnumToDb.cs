namespace CarServiceAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarMakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarStyles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Style = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarServiceType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.CarStyles");
            DropTable("dbo.CarMakes");
        }
    }
}
