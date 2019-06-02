namespace CrmBuisnessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update020619 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sells", "Check_CheckId", "dbo.Checks");
            DropIndex("dbo.Sells", new[] { "Check_CheckId" });
            RenameColumn(table: "dbo.Sells", name: "Check_CheckId", newName: "CheckId");
            AddColumn("dbo.Checks", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Sells", "CheckId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sells", "CheckId");
            AddForeignKey("dbo.Sells", "CheckId", "dbo.Checks", "CheckId", cascadeDelete: true);
            DropColumn("dbo.Sells", "ChekId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sells", "ChekId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Sells", "CheckId", "dbo.Checks");
            DropIndex("dbo.Sells", new[] { "CheckId" });
            AlterColumn("dbo.Sells", "CheckId", c => c.Int());
            DropColumn("dbo.Checks", "Price");
            RenameColumn(table: "dbo.Sells", name: "CheckId", newName: "Check_CheckId");
            CreateIndex("dbo.Sells", "Check_CheckId");
            AddForeignKey("dbo.Sells", "Check_CheckId", "dbo.Checks", "CheckId");
        }
    }
}
