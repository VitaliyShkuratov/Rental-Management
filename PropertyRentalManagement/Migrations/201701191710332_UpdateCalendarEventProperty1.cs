namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCalendarEventProperty1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalendarEvents", "start_date", c => c.DateTime(nullable: false));
            AddColumn("dbo.CalendarEvents", "end_date", c => c.DateTime(nullable: false));
            DropColumn("dbo.CalendarEvents", "StartDate");
            DropColumn("dbo.CalendarEvents", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CalendarEvents", "EndDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.CalendarEvents", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.CalendarEvents", "end_date");
            DropColumn("dbo.CalendarEvents", "start_date");
        }
    }
}
