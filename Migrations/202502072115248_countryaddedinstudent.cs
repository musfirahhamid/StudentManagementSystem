namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class countryaddedinstudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Country");
        }
    }
}
