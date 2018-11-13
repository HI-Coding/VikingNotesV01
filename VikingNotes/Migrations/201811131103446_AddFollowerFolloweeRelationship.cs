namespace VikingNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowerFolloweeRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attendances", "QuizId", "dbo.Quizs");
            DropIndex("dbo.Attendances", new[] { "QuizId" });
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeId);
            
            DropTable("dbo.Attendances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        QuizId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.QuizId, t.AttendeeId });
            
            DropForeignKey("dbo.Relationships", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Relationships", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Relationships", new[] { "FolloweeId" });
            DropIndex("dbo.Relationships", new[] { "FollowerId" });
            DropTable("dbo.Relationships");
            CreateIndex("dbo.Attendances", "AttendeeId");
            CreateIndex("dbo.Attendances", "QuizId");
            AddForeignKey("dbo.Attendances", "QuizId", "dbo.Quizs", "Id");
            AddForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
