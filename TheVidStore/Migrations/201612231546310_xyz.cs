namespace TheVidStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xyz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberOfMovies", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "YearOfRelease", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "CopiesAvi");
            DropColumn("dbo.Movies", "YearOfReleaseOfMovie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "YearOfReleaseOfMovie", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "CopiesAvi", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "YearOfRelease");
            DropColumn("dbo.Movies", "NumberOfMovies");
        }
    }
}
