namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredParameterToBuildingApartmentPerson : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Apartments", "ApartmentNumber", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Apartments", "NumberRooms", c => c.String(nullable: false));
            AlterColumn("dbo.Buildings", "Address", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.People", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Buildings", "Address", c => c.String(maxLength: 255));
            AlterColumn("dbo.Apartments", "NumberRooms", c => c.String());
            AlterColumn("dbo.Apartments", "ApartmentNumber", c => c.String(maxLength: 255));
        }
    }
}
