namespace TNAShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PaymentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PaymentType");
        }
    }
}
