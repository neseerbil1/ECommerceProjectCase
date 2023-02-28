namespace LayerDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryDiscounts", "Campaign_Id", c => c.Int());
            CreateIndex("dbo.CategoryDiscounts", "Campaign_Id");
            AddForeignKey("dbo.CategoryDiscounts", "Campaign_Id", "dbo.Campaigns", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CategoryDiscounts", "Campaign_Id", "dbo.Campaigns");
            DropIndex("dbo.CategoryDiscounts", new[] { "Campaign_Id" });
            DropColumn("dbo.CategoryDiscounts", "Campaign_Id");
        }
    }
}
