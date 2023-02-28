namespace LayerDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Campaigns", "DiscountId", "dbo.Discounts");
            DropIndex("dbo.Campaigns", new[] { "DiscountId" });
            DropColumn("dbo.Campaigns", "DiscountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Campaigns", "DiscountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Campaigns", "DiscountId");
            AddForeignKey("dbo.Campaigns", "DiscountId", "dbo.Discounts", "Id", cascadeDelete: true);
        }
    }
}
