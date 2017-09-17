namespace PortfolioManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trades", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Trades", new[] { "PortfolioId" });
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        Symbol = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        PortfolioId = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Portfolios", t => t.PortfolioId, cascadeDelete: true)
                .Index(t => t.PortfolioId);
            
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
                        TradeType = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.TradeId);
            
            DropForeignKey("dbo.Transactions", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Transactions", new[] { "PortfolioId" });
            DropTable("dbo.Transactions");
            CreateIndex("dbo.Trades", "PortfolioId");
            AddForeignKey("dbo.Trades", "PortfolioId", "dbo.Portfolios", "PortfolioId", cascadeDelete: true);
        }
    }
}
