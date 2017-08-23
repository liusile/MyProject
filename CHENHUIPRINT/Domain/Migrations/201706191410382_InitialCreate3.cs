namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysFlowNo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FlowNo = c.String(),
                        FlowNoType = c.Int(nullable: false),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SysFlowNo");
        }
    }
}
