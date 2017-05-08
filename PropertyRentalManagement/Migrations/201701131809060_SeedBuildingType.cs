namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedBuildingType : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT BuildingTypes ON");

            Sql("INSERT INTO BuildingTypes (Id, Name) VALUES (1, 'Apartment block')");
            Sql("INSERT INTO BuildingTypes (Id, Name) VALUES (2, 'Condominium')");
            Sql("INSERT INTO BuildingTypes (Id, Name) VALUES (3, 'Dormitory')");
            Sql("INSERT INTO BuildingTypes (Id, Name) VALUES (4, 'Duplex')");
            Sql("INSERT INTO BuildingTypes (Id, Name) VALUES (6, 'House')");

            Sql("INSERT INTO BuildingTypes (Id, Name) VALUES (7, 'Townhouse')");
            Sql("INSERT INTO BuildingTypes (Id, Name) VALUES (8, 'Villa')");
            Sql("INSERT INTO BuildingTypes (Id, Name) VALUES (9, 'Bungalow')");
            Sql("INSERT INTO BuildingTypes (Id, Name) VALUES (10, 'Unit')");
            Sql("INSERT INTO BuildingTypes (Id, Name) VALUES (11, 'Hut')");
            Sql("INSERT INTO BuildingTypes (Id, Name) VALUES (12, 'Igloo')");
        }

        public override void Down()
        {
        }
    }
}
