namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyAppartmentTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Apartments", "Building_Id", "dbo.Buildings");
            DropIndex("dbo.Apartments", new[] { "Building_Id" });
            RenameColumn(table: "dbo.Apartments", name: "Building_Id", newName: "BuildingId");
            AlterColumn("dbo.Apartments", "BuildingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Apartments", "BuildingId");
            AddForeignKey("dbo.Apartments", "BuildingId", "dbo.Buildings", "Id", cascadeDelete: true);
            DropColumn("dbo.Apartments", "BuidingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Apartments", "BuidingId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Apartments", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Apartments", new[] { "BuildingId" });
            AlterColumn("dbo.Apartments", "BuildingId", c => c.Int());
            RenameColumn(table: "dbo.Apartments", name: "BuildingId", newName: "Building_Id");
            CreateIndex("dbo.Apartments", "Building_Id");
            AddForeignKey("dbo.Apartments", "Building_Id", "dbo.Buildings", "Id");
        }
    }
}
