using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VVGames.BusinessLogic.DBModel;
using VVGames.Domain.Entities.Basket;

namespace VVGames.BusinessLogic.Core
{
    public class BasketApi
    {
        protected readonly BasketContext _ctx;
        public BasketApi(BasketContext ctx)
        {
            _ctx = ctx;
        }
        public virtual void AddAction(DBBasket item)
        {
            _ctx.Baskets.Add(item);
        }
        public virtual void RemoveAction(DBBasket item)
        {
            _ctx.Baskets.Remove(item);
        }
        public virtual IEnumerable<DBBasket> GetByUserAction(int userId)
        {
            return _ctx.Baskets
                       .Where(b => b.UserId == userId)
                       .ToList();
        }
        public virtual void SaveAction()
        {
            _ctx.SaveChanges();
        }
    }
}
