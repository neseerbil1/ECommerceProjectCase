namespace LayerDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Campaigns");
            AddColumn("dbo.Campaigns", "CampaignId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Campaigns", "CampaignId");
            DropColumn("dbo.Campaigns", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Campaigns", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Campaigns");
            DropColumn("dbo.Campaigns", "CampaignId");
            AddPrimaryKey("dbo.Campaigns", "Id");
        }
    }
}
