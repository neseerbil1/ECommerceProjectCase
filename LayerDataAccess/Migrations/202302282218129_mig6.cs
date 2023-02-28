namespace LayerDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryDiscounts", "ProductId", "dbo.Products");
            DropIndex("dbo.CategoryDiscounts", new[] { "ProductId" });
            RenameColumn(table: "dbo.CategoryDiscounts", name: "ProductId", newName: "Product_Id");
            AlterColumn("dbo.CategoryDiscounts", "Product_Id", c => c.Int());
            CreateIndex("dbo.CategoryDiscounts", "Product_Id");
            AddForeignKey("dbo.CategoryDiscounts", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryDiscounts", "Product_Id", "dbo.Products");
            DropIndex("dbo.CategoryDiscounts", new[] { "Product_Id" });
            AlterColumn("dbo.CategoryDiscounts", "Product_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.CategoryDiscounts", name: "Product_Id", newName: "ProductId");
            CreateIndex("dbo.CategoryDiscounts", "ProductId");
            AddForeignKey("dbo.CategoryDiscounts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
