namespace VikingNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsQuizsGenresProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quizs", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Quizs", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Quizs", new[] { "Author_Id" });
            DropIndex("dbo.Quizs", new[] { "Genre_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Quizs", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Quizs", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Quizs", "Author_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Quizs", "Genre_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Quizs", "Author_Id");
            CreateIndex("dbo.Quizs", "Genre_Id");
            AddForeignKey("dbo.Quizs", "Author_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Quizs", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quizs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Quizs", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Quizs", new[] { "Genre_Id" });
            DropIndex("dbo.Quizs", new[] { "Author_Id" });
            AlterColumn("dbo.Quizs", "Genre_Id", c => c.Int());
            AlterColumn("dbo.Quizs", "Author_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Quizs", "Description", c => c.String());
            AlterColumn("dbo.Quizs", "Title", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.Quizs", "Genre_Id");
            CreateIndex("dbo.Quizs", "Author_Id");
            AddForeignKey("dbo.Quizs", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Quizs", "Author_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
