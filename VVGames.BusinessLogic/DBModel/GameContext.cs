using System.Data.Entity;
using VVGames.Domain.Entities.Product;

namespace VVGames.BusinessLogic.DBModel
{
    public class GameContext : DbContext
    {
        public GameContext() : base("name=VVGames") { }

        public DbSet<DBGames> Games { get; set; }
    }
}
