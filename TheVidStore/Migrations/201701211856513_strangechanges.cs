namespace TheVidStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class strangechanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "YearOfRelease");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "YearOfRelease", c => c.Int(nullable: false));
        }
    }
}
