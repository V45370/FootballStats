namespace FootbalStats.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MatchResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Percentage1 = c.Int(nullable: false),
                        PercentageX = c.Int(nullable: false),
                        Percentage2 = c.Int(nullable: false),
                        Prediction = c.String(),
                        ExactScore1 = c.Int(nullable: false),
                        ExactScore2 = c.Int(nullable: false),
                        AverageScore = c.Single(nullable: false),
                        Team1 = c.String(),
                        Team2 = c.String(),
                        Team1Goals = c.Int(nullable: false),
                        Team2Goals = c.Int(nullable: false),
                        League_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leagues", t => t.League_Id)
                .Index(t => t.League_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchResults", "League_Id", "dbo.Leagues");
            DropIndex("dbo.MatchResults", new[] { "League_Id" });
            DropTable("dbo.MatchResults");
            DropTable("dbo.Leagues");
        }
    }
}
