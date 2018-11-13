namespace VikingNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCancelToQuiz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizs", "Cancel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quizs", "Cancel");
        }
    }
}
