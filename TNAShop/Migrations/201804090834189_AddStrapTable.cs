namespace TNAShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStrapTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Straps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StrapName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductStraps",
                c => new
                    {
                        StrapId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StrapId, t.ProductId });
            
            AddColumn("dbo.Products", "StrapId", c => c.String());
            AddColumn("dbo.Products", "Strap_Id", c => c.Int());
            CreateIndex("dbo.Products", "Strap_Id");
            AddForeignKey("dbo.Products", "Strap_Id", "dbo.Straps", "Id");
            DropColumn("dbo.Products", "Strap");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Strap", c => c.String());
            DropForeignKey("dbo.Products", "Strap_Id", "dbo.Straps");
            DropIndex("dbo.Products", new[] { "Strap_Id" });
            DropColumn("dbo.Products", "Strap_Id");
            DropColumn("dbo.Products", "StrapId");
            DropTable("dbo.ProductStraps");
            DropTable("dbo.Straps");
        }
    }
}
