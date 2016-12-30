namespace TheVidStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesincustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateOfBirth", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DateOfBirth");
        }
    }
}
