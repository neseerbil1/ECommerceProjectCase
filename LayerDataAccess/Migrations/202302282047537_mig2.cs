namespace LayerDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryDiscounts", "Product_Id", "dbo.Products");
            DropIndex("dbo.CategoryDiscounts", new[] { "Product_Id" });
            RenameColumn(table: "dbo.CategoryDiscounts", name: "Product_Id", newName: "ProductId");
            AlterColumn("dbo.CategoryDiscounts", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.CategoryDiscounts", "ProductId");
            AddForeignKey("dbo.CategoryDiscounts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryDiscounts", "ProductId", "dbo.Products");
            DropIndex("dbo.CategoryDiscounts", new[] { "ProductId" });
            AlterColumn("dbo.CategoryDiscounts", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.CategoryDiscounts", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.CategoryDiscounts", "Product_Id");
            AddForeignKey("dbo.CategoryDiscounts", "Product_Id", "dbo.Products", "Id");
        }
    }
}
