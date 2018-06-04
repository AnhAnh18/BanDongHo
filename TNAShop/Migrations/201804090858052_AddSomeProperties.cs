namespace TNAShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Strap_Id", "dbo.Straps");
            DropIndex("dbo.Products", new[] { "Strap_Id" });
            AddColumn("dbo.Straps", "Product_Id", c => c.Int());
            CreateIndex("dbo.ProductStraps", "StrapId");
            CreateIndex("dbo.ProductStraps", "ProductId");
            CreateIndex("dbo.Straps", "Product_Id");
            AddForeignKey("dbo.ProductStraps", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductStraps", "StrapId", "dbo.Straps", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Straps", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.Products", "StrapId");
            DropColumn("dbo.Products", "Strap_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Strap_Id", c => c.Int());
            AddColumn("dbo.Products", "StrapId", c => c.String());
            DropForeignKey("dbo.Straps", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductStraps", "StrapId", "dbo.Straps");
            DropForeignKey("dbo.ProductStraps", "ProductId", "dbo.Products");
            DropIndex("dbo.Straps", new[] { "Product_Id" });
            DropIndex("dbo.ProductStraps", new[] { "ProductId" });
            DropIndex("dbo.ProductStraps", new[] { "StrapId" });
            DropColumn("dbo.Straps", "Product_Id");
            CreateIndex("dbo.Products", "Strap_Id");
            AddForeignKey("dbo.Products", "Strap_Id", "dbo.Straps", "Id");
        }
    }
}
