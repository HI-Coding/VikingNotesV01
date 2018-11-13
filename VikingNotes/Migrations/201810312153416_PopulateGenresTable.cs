namespace VikingNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up() 
        {
            // step 8a
            Sql("INSERT INTO Genres ( Name) VALUES ('Medicinsk filosofi og videnskabsteori')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Medicinsk genetik')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Mikroskopisk anatomi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Embryologi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Makroskopisk anatomi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Neuroanatomi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Medicinsk biokemi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Fysiologi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Sundhedpsykologi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Epidemiologi og biostatistik')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Mikrobiologi og Immunologi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Miljø- og arbejdsjdsmedicin')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Farmakologi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Patologi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Inflammation')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Socialmedicin')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Abdomen')");
            Sql("INSERT INTO Genres ( Name) VALUES ('HLK')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Neuro')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Oftalmologi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Psykiatri')");
            Sql("INSERT INTO Genres ( Name) VALUES ('ØNH')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Klinisk Genetik')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Retsmedicin')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Akutmedicin')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Almen medicin')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Dermato-venerologi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Endokrinologi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Farmakologi')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Geriatri')");
            Sql("INSERT INTO Genres ( Name) VALUES ('Ortopædkirurgi')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres");
        }
    }
}
