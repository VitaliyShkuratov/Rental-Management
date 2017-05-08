namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveApartmentAndBuildingAddProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Buildings", "BuildingTypeId", "dbo.BuildingTypes");
            DropIndex("dbo.Buildings", new[] { "BuildingTypeId" });
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 255),
                        AppartmentNumber = c.String(maxLength: 255),
                        NumberRooms = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        BuildingTypeId = c.Int(nullable: false),
                        RentStarted = c.DateTime(),
                        RentFinished = c.DateTime(),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BuildingTypes", t => t.BuildingTypeId, cascadeDelete: true)
                .Index(t => t.BuildingTypeId);
            
            DropTable("dbo.Apartments");
            DropTable("dbo.Buildings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BuildingTypeId = c.Int(nullable: false),
                        DateOfCommissioning = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 255),
                        NumberRooms = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 255),
                        NumberRooms = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Properties", "BuildingTypeId", "dbo.BuildingTypes");
            DropIndex("dbo.Properties", new[] { "BuildingTypeId" });
            DropTable("dbo.Properties");
            CreateIndex("dbo.Buildings", "BuildingTypeId");
            AddForeignKey("dbo.Buildings", "BuildingTypeId", "dbo.BuildingTypes", "Id", cascadeDelete: true);
        }
    }
}
