namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockRecord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockRecordNo = c.String(),
                        Supplier = c.String(),
                        StockType = c.Int(nullable: false),
                        StorageManager = c.String(),
                        Purchaser = c.String(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockRecord");
        }
    }
}
