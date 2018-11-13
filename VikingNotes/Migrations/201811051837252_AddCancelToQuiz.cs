namespace VikingNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCancelToQuiz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizs", "Delete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quizs", "Delete");
        }
    }
}
