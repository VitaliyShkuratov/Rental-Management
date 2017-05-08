namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertiesToApartmentAndBuilding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apartments", "Available", c => c.Boolean(nullable: false));
            AddColumn("dbo.Buildings", "DateOfCommissioning", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buildings", "DateOfCommissioning");
            DropColumn("dbo.Apartments", "Available");
        }
    }
}
