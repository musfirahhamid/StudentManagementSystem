namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfieldsinstudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Student", "PhoneNumber", c => c.String());
            AddColumn("dbo.Student", "DateOfBirth", c => c.String());
            AddColumn("dbo.Student", "SSN", c => c.String());
            AddColumn("dbo.Student", "Zip", c => c.String());
            AddColumn("dbo.Student", "City", c => c.String());
            AddColumn("dbo.Student", "State", c => c.String());
            AddColumn("dbo.Student", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Address");
            DropColumn("dbo.Student", "State");
            DropColumn("dbo.Student", "City");
            DropColumn("dbo.Student", "Zip");
            DropColumn("dbo.Student", "SSN");
            DropColumn("dbo.Student", "DateOfBirth");
            DropColumn("dbo.Student", "PhoneNumber");
            DropColumn("dbo.Student", "Email");
        }
    }
}
