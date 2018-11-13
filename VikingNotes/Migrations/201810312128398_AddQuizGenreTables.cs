namespace VikingNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuizGenreTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quizs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        CreationDateTime = c.DateTime(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                        Genre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quizs", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Quizs", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Quizs", new[] { "Genre_Id" });
            DropIndex("dbo.Quizs", new[] { "Author_Id" });
            DropTable("dbo.Quizs");
            DropTable("dbo.Genres");
        }
    }
}
