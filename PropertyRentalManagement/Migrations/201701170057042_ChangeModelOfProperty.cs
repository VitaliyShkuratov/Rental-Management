namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeModelOfProperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Apartments", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Apartments", new[] { "BuildingId" });
            AddColumn("dbo.Apartments", "Address", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Buildings", "NumberRooms", c => c.String(nullable: false));
            AddColumn("dbo.Buildings", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Buildings", "Available", c => c.Boolean(nullable: false));
            DropColumn("dbo.Apartments", "ApartmentNumber");
            DropColumn("dbo.Apartments", "BuildingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Apartments", "BuildingId", c => c.Int(nullable: false));
            AddColumn("dbo.Apartments", "ApartmentNumber", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Buildings", "Available");
            DropColumn("dbo.Buildings", "Price");
            DropColumn("dbo.Buildings", "NumberRooms");
            DropColumn("dbo.Apartments", "Address");
            CreateIndex("dbo.Apartments", "BuildingId");
            AddForeignKey("dbo.Apartments", "BuildingId", "dbo.Buildings", "Id", cascadeDelete: true);
        }
    }
}
