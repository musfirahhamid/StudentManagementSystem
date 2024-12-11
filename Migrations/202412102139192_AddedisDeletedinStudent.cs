namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedisDeletedinStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "IsDeleted");
        }
    }
}
