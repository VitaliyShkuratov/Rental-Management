namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedPersonType : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT PersonTypes ON");

            Sql("INSERT INTO PersonTypes (Id, Name) VALUES (1, 'Owner')");
            Sql("INSERT INTO PersonTypes (Id, Name) VALUES (2, 'Manager')");
            Sql("INSERT INTO PersonTypes (Id, Name) VALUES (3, 'Tenant')");
        }

        public override void Down()
        {
        }
    }
}
