namespace PortfolioManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TradeType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trades", "TradeType", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trades", "TradeType");
        }
    }
}
