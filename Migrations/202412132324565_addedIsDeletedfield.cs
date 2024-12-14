namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIsDeletedfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "IsDeleted");
        }
    }
}
