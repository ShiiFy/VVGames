namespace VVGames.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DBGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Articul = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 30),
                        Genres = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageUrl = c.String(nullable: false),
                        Description = c.String(maxLength: 300),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DBGames");
        }
    }
}
