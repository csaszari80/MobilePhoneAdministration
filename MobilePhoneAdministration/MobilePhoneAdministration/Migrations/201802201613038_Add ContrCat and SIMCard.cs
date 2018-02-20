namespace MobilePhoneAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContrCatandSIMCard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContractCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SIMCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractId = c.String(),
                        PhoneNumber = c.String(),
                        ContractCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractCategories", t => t.ContractCategory_Id)
                .Index(t => t.ContractCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SIMCards", "ContractCategory_Id", "dbo.ContractCategories");
            DropIndex("dbo.SIMCards", new[] { "ContractCategory_Id" });
            DropTable("dbo.SIMCards");
            DropTable("dbo.ContractCategories");
        }
    }
}
