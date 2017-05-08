namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateImageModelTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ImageModels", "ImageData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageModels", "ImageData", c => c.Binary(nullable: false));
        }
    }
}
