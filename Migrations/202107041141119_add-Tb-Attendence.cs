namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTbAttendence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendences",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CourseId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .Index(t => t.CourseId)
                .Index(t => t.AttendeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendences", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendences", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendences", new[] { "AttendeeId" });
            DropIndex("dbo.Attendences", new[] { "CourseId" });
            DropTable("dbo.Attendences");
        }
    }
}
