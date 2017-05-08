namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPricePropertyToApartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apartments", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Apartments", "Price");
        }
    }
}
