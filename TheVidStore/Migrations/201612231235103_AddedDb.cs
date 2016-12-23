namespace TheVidStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "CopiesAvi", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "YearOfReleaseOfMovie", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "GenreOfMovie", c => c.String());
            DropColumn("dbo.Movies", "NumberOfCopies");
            DropColumn("dbo.Movies", "YearOfRelease");
            DropColumn("dbo.Movies", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            AddColumn("dbo.Movies", "YearOfRelease", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "NumberOfCopies", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "GenreOfMovie");
            DropColumn("dbo.Movies", "YearOfReleaseOfMovie");
            DropColumn("dbo.Movies", "CopiesAvi");
        }
    }
}
