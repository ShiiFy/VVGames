namespace VVGames.BusinessLogic.MigrationsUser
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VVGames.BusinessLogic.DBModel.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"MigrationsUser";
            ContextKey = "VVGames.BusinessLogic.DBModel.UserContext";
        }

        protected override void Seed(VVGames.BusinessLogic.DBModel.UserContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
