namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCalendarEventProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalendarEvents", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CalendarEvents", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.CalendarEvents", "start_date");
            DropColumn("dbo.CalendarEvents", "end_date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CalendarEvents", "end_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.CalendarEvents", "start_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.CalendarEvents", "EndDate");
            DropColumn("dbo.CalendarEvents", "StartDate");
        }
    }
}
