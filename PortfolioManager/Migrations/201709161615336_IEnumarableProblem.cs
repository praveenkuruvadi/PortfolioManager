namespace PortfolioManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IEnumarableProblem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommodityStocks",
                c => new
                    {
                        EntryId = c.Int(nullable: false, identity: true),
                        Symbol = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        OriginalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PortfolioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntryId)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioId, cascadeDelete: true)
                .Index(t => t.PortfolioId);
            
            CreateTable(
                "dbo.EquityStocks",
                c => new
                    {
                        EntryId = c.Int(nullable: false, identity: true),
                        Symbol = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        OriginalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PortfolioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntryId)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioId, cascadeDelete: true)
                .Index(t => t.PortfolioId);
            
            CreateTable(
                "dbo.Trades",
                c => new
                    {
                        TradeId = c.Int(nullable: false, identity: true),
                        Symbol = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PortfolioId = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        BuyPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TradeId)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioId, cascadeDelete: true)
                .Index(t => t.PortfolioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trades", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.EquityStocks", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.CommodityStocks", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Trades", new[] { "PortfolioId" });
            DropIndex("dbo.EquityStocks", new[] { "PortfolioId" });
            DropIndex("dbo.CommodityStocks", new[] { "PortfolioId" });
            DropTable("dbo.Trades");
            DropTable("dbo.EquityStocks");
            DropTable("dbo.CommodityStocks");
        }
    }
}
