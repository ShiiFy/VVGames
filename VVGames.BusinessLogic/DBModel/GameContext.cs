using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.Domain.Entities.Product;

namespace VVGames.BusinessLogic.DBModel
{
    public class GameContext : DbContext
    {
        public GameContext() : base("name=VVGames")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<GameContext>());
        }

        public DbSet<DBGames> Games { get; set; }
    }
}
