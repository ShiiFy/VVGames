using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using VVGames.Domain.Entities.Basket;
using VVGames.Domain.Entities.Product;
using VVGames.Domain.Entities.User;

namespace VVGames.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=VVGames") { }

        public virtual DbSet<DBUser> Users { get; set; }
    }
}
