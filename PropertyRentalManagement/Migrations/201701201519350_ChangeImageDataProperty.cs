namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeImageDataProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ImageModels", "ImageData", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ImageModels", "ImageData", c => c.Int(nullable: false));
        }
    }
}
