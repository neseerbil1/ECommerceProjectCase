namespace LayerDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryDiscounts", "Product_Id", c => c.Int());
            AddColumn("dbo.Discounts", "DiscountRate", c => c.Double(nullable: false));
            CreateIndex("dbo.CategoryDiscounts", "Product_Id");
            AddForeignKey("dbo.CategoryDiscounts", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryDiscounts", "Product_Id", "dbo.Products");
            DropIndex("dbo.CategoryDiscounts", new[] { "Product_Id" });
            DropColumn("dbo.Discounts", "DiscountRate");
            DropColumn("dbo.CategoryDiscounts", "Product_Id");
        }
    }
}
