namespace PortfolioManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePortfolioId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommodityStocks", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.EquityStocks", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Trades", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Customers", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Customers", new[] { "PortfolioId" });
            DropIndex("dbo.CommodityStocks", new[] { "PortfolioId" });
            DropIndex("dbo.EquityStocks", new[] { "PortfolioId" });
            DropIndex("dbo.Trades", new[] { "PortfolioId" });
            RenameColumn(table: "dbo.Customers", name: "PortfolioId", newName: "CustomerPortfolio_PortfolioId");
            AlterColumn("dbo.Customers", "CustomerName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "CustomerPortfolio_PortfolioId", c => c.Int());
            CreateIndex("dbo.Customers", "CustomerPortfolio_PortfolioId");
            AddForeignKey("dbo.Customers", "CustomerPortfolio_PortfolioId", "dbo.Portfolios", "PortfolioId");
            DropTable("dbo.CommodityStocks");
            DropTable("dbo.EquityStocks");
            DropTable("dbo.Trades");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.TradeId);
            
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
                .PrimaryKey(t => t.EntryId);
            
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
                .PrimaryKey(t => t.EntryId);
            
            DropForeignKey("dbo.Customers", "CustomerPortfolio_PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Customers", new[] { "CustomerPortfolio_PortfolioId" });
            AlterColumn("dbo.Customers", "CustomerPortfolio_PortfolioId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "CustomerName", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Customers", name: "CustomerPortfolio_PortfolioId", newName: "PortfolioId");
            CreateIndex("dbo.Trades", "PortfolioId");
            CreateIndex("dbo.EquityStocks", "PortfolioId");
            CreateIndex("dbo.CommodityStocks", "PortfolioId");
            CreateIndex("dbo.Customers", "PortfolioId");
            AddForeignKey("dbo.Customers", "PortfolioId", "dbo.Portfolios", "PortfolioId", cascadeDelete: true);
            AddForeignKey("dbo.Trades", "PortfolioId", "dbo.Portfolios", "PortfolioId", cascadeDelete: true);
            AddForeignKey("dbo.EquityStocks", "PortfolioId", "dbo.Portfolios", "PortfolioId", cascadeDelete: true);
            AddForeignKey("dbo.CommodityStocks", "PortfolioId", "dbo.Portfolios", "PortfolioId", cascadeDelete: true);
        }
    }
}
