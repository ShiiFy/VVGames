namespace VVGames.BusinessLogic.MigrationsBasket
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBasketTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DBBaskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DBBaskets");
        }
    }
}
