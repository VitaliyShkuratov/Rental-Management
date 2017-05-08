namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablePropertyImageModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertyImageModels",
                c => new
                    {
                        ImageModelId = c.Int(nullable: false),
                        PropertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ImageModelId, t.PropertyId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PropertyImageModels");
        }
    }
}
