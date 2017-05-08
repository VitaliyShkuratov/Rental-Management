namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameEventsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalendarEvents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        text = c.String(nullable: false),
                        start_date = c.DateTime(nullable: false),
                        end_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            DropTable("dbo.Events");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventText = c.String(maxLength: 255),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.CalendarEvents");
        }
    }
}
