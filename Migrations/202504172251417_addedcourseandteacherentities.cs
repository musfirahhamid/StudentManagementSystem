namespace StudentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcourseandteacherentities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Student", "SessionId", "dbo.Session");
            AddColumn("dbo.Course", "CreditHours", c => c.Int(nullable: false));
            AddColumn("dbo.Course", "Status", c => c.String());
            AddColumn("dbo.Course", "SessionId", c => c.Int());
            AddColumn("dbo.Course", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Course", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Session", "Course_Id", c => c.Int());
            AddColumn("dbo.Student", "CourseId", c => c.Int());
            AddColumn("dbo.Student", "Session_Id", c => c.Int());
            AddColumn("dbo.Teacher", "SessionId", c => c.Int());
            AddColumn("dbo.Teacher", "CourseId", c => c.Int());
            CreateIndex("dbo.Course", "SessionId");
            CreateIndex("dbo.Session", "Course_Id");
            CreateIndex("dbo.Student", "CourseId");
            CreateIndex("dbo.Student", "Session_Id");
            CreateIndex("dbo.Teacher", "SessionId");
            CreateIndex("dbo.Teacher", "CourseId");
            AddForeignKey("dbo.Student", "CourseId", "dbo.Session", "Id");
            AddForeignKey("dbo.Teacher", "CourseId", "dbo.Session", "Id");
            AddForeignKey("dbo.Teacher", "SessionId", "dbo.Session", "Id");
            AddForeignKey("dbo.Course", "SessionId", "dbo.Session", "Id");
            AddForeignKey("dbo.Session", "Course_Id", "dbo.Course", "Id");
            AddForeignKey("dbo.Student", "CourseId", "dbo.Course", "Id");
            AddForeignKey("dbo.Teacher", "CourseId", "dbo.Course", "Id");
            AddForeignKey("dbo.Student", "Session_Id", "dbo.Session", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "Session_Id", "dbo.Session");
            DropForeignKey("dbo.Teacher", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Student", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Session", "Course_Id", "dbo.Course");
            DropForeignKey("dbo.Course", "SessionId", "dbo.Session");
            DropForeignKey("dbo.Teacher", "SessionId", "dbo.Session");
            DropForeignKey("dbo.Teacher", "CourseId", "dbo.Session");
            DropForeignKey("dbo.Student", "CourseId", "dbo.Session");
            DropIndex("dbo.Teacher", new[] { "CourseId" });
            DropIndex("dbo.Teacher", new[] { "SessionId" });
            DropIndex("dbo.Student", new[] { "Session_Id" });
            DropIndex("dbo.Student", new[] { "CourseId" });
            DropIndex("dbo.Session", new[] { "Course_Id" });
            DropIndex("dbo.Course", new[] { "SessionId" });
            DropColumn("dbo.Teacher", "CourseId");
            DropColumn("dbo.Teacher", "SessionId");
            DropColumn("dbo.Student", "Session_Id");
            DropColumn("dbo.Student", "CourseId");
            DropColumn("dbo.Session", "Course_Id");
            DropColumn("dbo.Course", "UpdatedDate");
            DropColumn("dbo.Course", "CreatedDate");
            DropColumn("dbo.Course", "SessionId");
            DropColumn("dbo.Course", "Status");
            DropColumn("dbo.Course", "CreditHours");
            AddForeignKey("dbo.Student", "SessionId", "dbo.Session", "Id");
        }
    }
}
