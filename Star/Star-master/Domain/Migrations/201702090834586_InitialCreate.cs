namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        ProductTypeId = c.Int(nullable: false),
                        ProdcutId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 128),
                        ProductImgUrl = c.String(),
                        Introduce = c.String(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => new { t.UserName, t.ProductTypeId, t.ProdcutId, t.ProductName })
                .ForeignKey("dbo.ProductType", t => new { t.UserName, t.ProductTypeId }, cascadeDelete: true)
                .Index(t => new { t.UserName, t.ProductTypeId });
            
            CreateTable(
                "dbo.ProductType",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        ProductTypeId = c.Int(nullable: false, identity: true),
                        ProductTypeName = c.String(),
                        ParentProductTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserName, t.ProductTypeId });
            
            CreateTable(
                "dbo.Test",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        ProductTypeId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => new { t.UserName, t.ProductTypeId });
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Pwd = c.String(),
                        HeadImgUrl = c.String(),
                        IsValid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", new[] { "UserName", "ProductTypeId" }, "dbo.ProductType");
            DropIndex("dbo.Product", new[] { "UserName", "ProductTypeId" });
            DropTable("dbo.User");
            DropTable("dbo.Test");
            DropTable("dbo.ProductType");
            DropTable("dbo.Product");
        }
    }
}
