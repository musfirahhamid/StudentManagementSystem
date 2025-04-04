namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecommonmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Student", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Teacher", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Teacher", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teacher", "UpdatedDate");
            DropColumn("dbo.Teacher", "CreatedDate");
            DropColumn("dbo.Student", "UpdatedDate");
            DropColumn("dbo.Student", "CreatedDate");
        }
    }
}
