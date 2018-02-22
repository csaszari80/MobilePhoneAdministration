namespace MobilePhoneAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SIMCardContractcategoryRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SIMCards", "ContractCategory_Id", "dbo.ContractCategories");
            DropIndex("dbo.SIMCards", new[] { "ContractCategory_Id" });
            AlterColumn("dbo.SIMCards", "ContractCategory_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.SIMCards", "ContractCategory_Id");
            AddForeignKey("dbo.SIMCards", "ContractCategory_Id", "dbo.ContractCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SIMCards", "ContractCategory_Id", "dbo.ContractCategories");
            DropIndex("dbo.SIMCards", new[] { "ContractCategory_Id" });
            AlterColumn("dbo.SIMCards", "ContractCategory_Id", c => c.Int());
            CreateIndex("dbo.SIMCards", "ContractCategory_Id");
            AddForeignKey("dbo.SIMCards", "ContractCategory_Id", "dbo.ContractCategories", "Id");
        }
    }
}
