namespace TNAShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "CatgoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CatgoryId", c => c.Int(nullable: false));
        }
    }
}
