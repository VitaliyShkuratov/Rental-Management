namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitializeBuildingsApartmenysPersons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        ApartmentNumber = c.String(maxLength: 255),
                        NumberRooms = c.String(),
                        BuidingId = c.Int(nullable: false),
                        Building_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.Building_Id)
                .Index(t => t.Building_Id);

            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 255),
                        BuildingTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BuildingTypes", t => t.BuildingTypeId, cascadeDelete: true)
                .Index(t => t.BuildingTypeId);

            CreateTable(
                "dbo.BuildingTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        PersonTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonTypes", t => t.PersonTypeId, cascadeDelete: true)
                .Index(t => t.PersonTypeId);

            CreateTable(
                "dbo.PersonTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.People", "PersonTypeId", "dbo.PersonTypes");
            DropForeignKey("dbo.Apartments", "Building_Id", "dbo.Buildings");
            DropForeignKey("dbo.Buildings", "BuildingTypeId", "dbo.BuildingTypes");
            DropIndex("dbo.People", new[] { "PersonTypeId" });
            DropIndex("dbo.Buildings", new[] { "BuildingTypeId" });
            DropIndex("dbo.Apartments", new[] { "Building_Id" });
            DropTable("dbo.PersonTypes");
            DropTable("dbo.People");
            DropTable("dbo.BuildingTypes");
            DropTable("dbo.Buildings");
            DropTable("dbo.Apartments");
        }
    }
}
