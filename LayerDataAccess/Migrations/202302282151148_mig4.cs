namespace LayerDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryDiscounts", "Campaign_Id", "dbo.Campaigns");
            DropIndex("dbo.CategoryDiscounts", new[] { "Campaign_Id" });
            AddColumn("dbo.Campaigns", "DiscountId", c => c.Int(nullable: false));
            CreateIndex("dbo.Campaigns", "DiscountId");
            AddForeignKey("dbo.Campaigns", "DiscountId", "dbo.Discounts", "Id", cascadeDelete: true);
            DropColumn("dbo.CategoryDiscounts", "Campaign_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CategoryDiscounts", "Campaign_Id", c => c.Int());
            DropForeignKey("dbo.Campaigns", "DiscountId", "dbo.Discounts");
            DropIndex("dbo.Campaigns", new[] { "DiscountId" });
            DropColumn("dbo.Campaigns", "DiscountId");
            CreateIndex("dbo.CategoryDiscounts", "Campaign_Id");
            AddForeignKey("dbo.CategoryDiscounts", "Campaign_Id", "dbo.Campaigns", "Id");
        }
    }
}
