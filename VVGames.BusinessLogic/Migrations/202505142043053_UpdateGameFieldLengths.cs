namespace VVGames.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGameFieldLengths : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DBGames", "Name", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.DBGames", "ShortDescription", c => c.String(maxLength: 300));
            AlterColumn("dbo.DBGames", "Description", c => c.String(maxLength: 1500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DBGames", "Description", c => c.String(maxLength: 400));
            AlterColumn("dbo.DBGames", "ShortDescription", c => c.String(maxLength: 150));
            AlterColumn("dbo.DBGames", "Name", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
