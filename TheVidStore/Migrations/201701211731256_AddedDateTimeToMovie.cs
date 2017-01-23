namespace TheVidStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateTimeToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Year", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Year");
        }
    }
}
