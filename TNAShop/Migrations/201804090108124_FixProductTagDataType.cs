namespace TNAShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixProductTagDataType : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProductTags");
            AlterColumn("dbo.ProductTags", "ProductId", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductTags", "TagId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ProductTags", new[] { "ProductId", "TagId" });
            CreateIndex("dbo.ProductTags", "ProductId");
            CreateIndex("dbo.ProductTags", "TagId");
            AddForeignKey("dbo.ProductTags", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductTags", "TagId", "dbo.Tags", "TagId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.ProductTags", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductTags", new[] { "TagId" });
            DropIndex("dbo.ProductTags", new[] { "ProductId" });
            DropPrimaryKey("dbo.ProductTags");
            AlterColumn("dbo.ProductTags", "TagId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ProductTags", "ProductId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ProductTags", new[] { "ProductId", "TagId" });
        }
    }
}
