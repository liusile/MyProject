namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        ActivityId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Time = c.DateTime(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => new { t.UserName, t.ActivityId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Activity");
        }
    }
}
