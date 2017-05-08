namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class ChangeImageModelTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ImageModels", "PropertyId");
        }

        public override void Down()
        {
            AddColumn("dbo.ImageModels", "PropertyId", c => c.Int(nullable: false));
        }
    }
}
