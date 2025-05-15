using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.Domain.Entities.Basket;
using VVGames.Domain.Entities.Product;
using VVGames.Domain.Entities.User;

namespace VVGames.BusinessLogic.DBModel
{
    public class BasketContext : DbContext
    {
        public BasketContext()
            : base("name=VVGames")
        { 

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<DBUser>();
            modelBuilder.Ignore<DBGames>();

            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<DBBasket> Baskets { get; set; }
    }
}
