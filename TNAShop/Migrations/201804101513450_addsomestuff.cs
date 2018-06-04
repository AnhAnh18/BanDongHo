namespace TNAShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsomestuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "AddedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "AddedDate");
        }
    }
}
