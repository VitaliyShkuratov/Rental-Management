namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyIdPropertyApartment : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Apartments");
            AlterColumn("dbo.Apartments", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Apartments", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Apartments");
            AlterColumn("dbo.Apartments", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Apartments", "Id");
        }
    }
}
