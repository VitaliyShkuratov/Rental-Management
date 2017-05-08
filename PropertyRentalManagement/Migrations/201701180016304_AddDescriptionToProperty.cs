namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "Description");
        }
    }
}
