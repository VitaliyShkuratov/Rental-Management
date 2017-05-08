namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameFields1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageModels", "PropertyId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImageModels", "PropertyId");
        }
    }
}
