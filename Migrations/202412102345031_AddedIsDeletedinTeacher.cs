namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsDeletedinTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teacher", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teacher", "IsDeleted");
        }
    }
}
