namespace FootbalStats.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoccerStatGoalByMinute : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Leagues",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        Name = c.String(),
            //    })
            //    .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.MatchResults",
            //    c => new
            //    {
            //        Id = c.Int(nullable: false, identity: true),
            //        Date = c.DateTime(nullable: false),
            //        Percentage1 = c.Int(nullable: false),
            //        PercentageX = c.Int(nullable: false),
            //        Percentage2 = c.Int(nullable: false),
            //        Prediction = c.String(),
            //        ExactScore1 = c.Int(nullable: false),
            //        ExactScore2 = c.Int(nullable: false),
            //        AverageScore = c.Single(nullable: false),
            //        Team1 = c.String(),
            //        Team2 = c.String(),
            //        Team1Goals = c.Int(nullable: false),
            //        Team2Goals = c.Int(nullable: false),
            //        League_Id = c.Int(),
            //    })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Leagues", t => t.League_Id)
            //    .Index(t => t.League_Id);

            CreateTable(
                "dbo.SoccerStatGoalByMinutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Team = c.String(),
                        Do10Scored = c.Int(nullable: false),
                        Do20Scored = c.Int(nullable: false),
                        Do30Scored = c.Int(nullable: false),
                        Do40Scored = c.Int(nullable: false),
                        Do50Scored = c.Int(nullable: false),
                        Do60Scored = c.Int(nullable: false),
                        Do70Scored = c.Int(nullable: false),
                        Do80Scored = c.Int(nullable: false),
                        Do90Scored = c.Int(nullable: false),
                        Do10Conceded = c.Int(nullable: false),
                        Do20Conceded = c.Int(nullable: false),
                        Do30Conceded = c.Int(nullable: false),
                        Do40Conceded = c.Int(nullable: false),
                        Do50Conceded = c.Int(nullable: false),
                        Do60Conceded = c.Int(nullable: false),
                        Do70Conceded = c.Int(nullable: false),
                        Do80Conceded = c.Int(nullable: false),
                        Do90Conceded = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchResults", "League_Id", "dbo.Leagues");
            DropIndex("dbo.MatchResults", new[] { "League_Id" });
            DropTable("dbo.SoccerStatGoalByMinutes");
            DropTable("dbo.MatchResults");
            DropTable("dbo.Leagues");
        }
    }
}
