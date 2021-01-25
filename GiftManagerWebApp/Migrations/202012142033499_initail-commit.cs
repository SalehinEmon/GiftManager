namespace GiftManagerWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initailcommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        WhosEvent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOfGift = c.String(),
                        Amount = c.Double(nullable: false),
                        Address = c.String(),
                        PayersName = c.String(),
                        PhoneNo = c.String(),
                        Email = c.String(),
                        LocalSerialId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        AddedBy = c.Int(nullable: false),
                        Date = c.String(),
                        Time = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        PasswordSalt = c.String(),
                        Role = c.String(nullable: false),
                        PhoneNo = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Gifts");
            DropTable("dbo.EventModels");
        }
    }
}
