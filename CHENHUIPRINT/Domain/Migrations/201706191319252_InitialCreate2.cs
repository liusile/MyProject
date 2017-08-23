namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductType = c.String(),
                        ProductSubType = c.String(),
                        Brand = c.String(),
                        Spec = c.String(),
                        Grammage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TonOfPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Num = c.Int(nullable: false),
                        Unit = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockRecord_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.StockRecord", t => t.StockRecord_Id)
                .Index(t => t.StockRecord_Id);
            
            AddColumn("dbo.StockRecord", "OperPeople", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "StockRecord_Id", "dbo.StockRecord");
            DropIndex("dbo.Product", new[] { "StockRecord_Id" });
            DropColumn("dbo.StockRecord", "OperPeople");
            DropTable("dbo.Product");
        }
    }
}
