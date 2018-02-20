namespace MobilePhoneAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CPID = c.Int(nullable: false),
                        ADlogin = c.String(),
                        Active = c.Boolean(nullable: false),
                        Editable = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                        CostPlace_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CostPlaces", t => t.CostPlace_Id, cascadeDelete: true)
                .Index(t => t.CostPlace_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "CostPlace_Id", "dbo.CostPlaces");
            DropIndex("dbo.Users", new[] { "CostPlace_Id" });
            DropTable("dbo.Users");
        }
    }
}
