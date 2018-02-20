namespace MobilePhoneAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CostPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CostCode = c.String(nullable: false),
                        CostName = c.String(nullable: false),
                        OrganizationCode = c.String(),
                        OrganizationName = c.String(),
                        ForwardedBill = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CostPlaces");
        }
    }
}
