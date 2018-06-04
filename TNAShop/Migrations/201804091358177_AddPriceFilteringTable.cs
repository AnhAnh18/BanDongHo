namespace TNAShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceFilteringTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceFilterings",
                c => new
                    {
                        Min = c.Double(nullable: false),
                        Max = c.Double(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.Min, t.Max });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PriceFilterings");
        }
    }
}
