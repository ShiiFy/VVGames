using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.BusinessLogic.Core;
using VVGames.BusinessLogic.DBModel;
using VVGames.BusinessLogic.Interface;
using VVGames.Domain.Entities.Basket;
using VVGames.Domain.Entities.Product;

namespace VVGames.BusinessLogic.BL
{
    public class BasketBL : UserApi, IBasket
    {
        public List<Games> GetAllProduct(int userId)
        {
            throw new NotImplementedException();
        }
        public void AddProduct(int userId, int productId, int countProduct)
        {
            throw new NotImplementedException();
        }
        public void UpdateProduct(int userId, int productId, int countProduct)
        {
            throw new NotImplementedException();
        }
        public void RemoveProduct(int userId, int productId)
        {
            throw new NotImplementedException();
        }
        public void RemoveAll(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
