namespace PropertyRentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePersonFromDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "PersonTypeId", "dbo.PersonTypes");
            DropIndex("dbo.People", new[] { "PersonTypeId" });
            DropTable("dbo.People");
            DropTable("dbo.PersonTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        PersonTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.People", "PersonTypeId");
            AddForeignKey("dbo.People", "PersonTypeId", "dbo.PersonTypes", "Id", cascadeDelete: true);
        }
    }
}
