namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIdDeletedtoDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Department", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Department", "IsDeleted");
        }
    }
}
