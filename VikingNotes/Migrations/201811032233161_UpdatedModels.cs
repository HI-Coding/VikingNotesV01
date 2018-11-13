namespace VikingNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quizs", "Title", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quizs", "Title", c => c.String(nullable: false));
        }
    }
}
