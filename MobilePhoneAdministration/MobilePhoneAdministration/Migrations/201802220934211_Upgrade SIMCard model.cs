namespace MobilePhoneAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpgradeSIMCardmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SIMCards", "DeviceNumber", c => c.String());
            AddColumn("dbo.SIMCards", "ContractDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SIMCards", "CardIMEI", c => c.String());
            AddColumn("dbo.SIMCards", "PIN1", c => c.String());
            AddColumn("dbo.SIMCards", "PIN2", c => c.String());
            AddColumn("dbo.SIMCards", "PUK1", c => c.String());
            AddColumn("dbo.SIMCards", "PUK2", c => c.String());
            AddColumn("dbo.SIMCards", "Comment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SIMCards", "Comment");
            DropColumn("dbo.SIMCards", "PUK2");
            DropColumn("dbo.SIMCards", "PUK1");
            DropColumn("dbo.SIMCards", "PIN2");
            DropColumn("dbo.SIMCards", "PIN1");
            DropColumn("dbo.SIMCards", "CardIMEI");
            DropColumn("dbo.SIMCards", "ContractDate");
            DropColumn("dbo.SIMCards", "DeviceNumber");
        }
    }
}
