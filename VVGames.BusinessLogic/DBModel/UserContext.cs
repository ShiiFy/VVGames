using System.Data.Entity;
using VVGames.Domain.Entities.User;

namespace VVGames.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=VVGames") { }

        public virtual DbSet<DBUser> Users { get; set; }
    }
}
