namespace VVGames.BusinessLogic.MigrationsUser
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DBUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        Name = c.String(maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        PasswordHash = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(maxLength: 15),
                        IsBlocked = c.Boolean(nullable: false),
                        Level = c.Int(nullable: false),
                        LoginDateTime = c.DateTime(nullable: false),
                        LastDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DBUsers");
        }
    }
}
