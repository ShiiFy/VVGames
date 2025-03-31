using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.BusinessLogic.Core;
using VVGames.BusinessLogic.Interface;
using VVGames.Domain.Entities.Basket;
using VVGames.Domain.Entities.Product;

namespace VVGames.BusinessLogic.BL
{
    public class BasketBL : UserApi, IBasket
    {
        public List<Games> GetAllProduct(int UserID)
        {
            throw new NotImplementedException();
        }
        public void AddProduct(int UserID, int ProductID, int countProduct)
        {
            throw new NotImplementedException();
        }
        public void UpdateProduct(int UserID, int ProductID, int countProduct)
        {
            throw new NotImplementedException();
        }
        public void RemoveProduct(int UserID, int ProductID)
        {
            throw new NotImplementedException();
        }
        public void RemoveAll(int UserID)
        {
            throw new NotImplementedException();
        }
    }
}
