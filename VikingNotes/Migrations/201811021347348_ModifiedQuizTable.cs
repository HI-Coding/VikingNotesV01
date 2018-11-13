namespace VikingNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedQuizTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizs", "Creation", c => c.DateTime(nullable: false));
            DropColumn("dbo.Quizs", "CreationDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quizs", "CreationDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Quizs", "Creation");
        }
    }
}
