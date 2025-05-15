namespace VVGames.BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShortDescriptionToGames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DBGames", "ShortDescription", c => c.String(maxLength: 150));
            AlterColumn("dbo.DBGames", "Description", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DBGames", "Description", c => c.String(maxLength: 300));
            DropColumn("dbo.DBGames", "ShortDescription");
        }
    }
}
