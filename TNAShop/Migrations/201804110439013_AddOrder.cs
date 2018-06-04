namespace TNAShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDets",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductPrice = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Email = c.String(),
                        TotalCost = c.Double(nullable: false),
                        VendorId = c.Int(nullable: false),
                        CustomerName = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        TransportionType = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Vendors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VendorName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.OrderDets", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDets", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderDets", new[] { "ProductId" });
            DropIndex("dbo.OrderDets", new[] { "OrderId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDets");
        }
    }
}
