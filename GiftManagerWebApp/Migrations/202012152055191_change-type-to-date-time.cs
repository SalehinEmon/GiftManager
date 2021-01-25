namespace GiftManagerWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetypetodatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gifts", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Gifts", "Time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gifts", "Time", c => c.String());
            AlterColumn("dbo.Gifts", "Date", c => c.String());
        }
    }
}
