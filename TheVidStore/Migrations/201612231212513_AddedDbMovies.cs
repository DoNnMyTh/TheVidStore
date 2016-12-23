namespace TheVidStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDbMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberOfCopies", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "YearOfRelease", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genre", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "Genre");
            DropColumn("dbo.Movies", "YearOfRelease");
            DropColumn("dbo.Movies", "NumberOfCopies");
        }
    }
}
