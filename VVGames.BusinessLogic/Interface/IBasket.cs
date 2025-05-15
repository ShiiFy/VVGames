using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.BusinessLogic.DBModel;
using VVGames.Domain.Entities.Basket;
using VVGames.Domain.Entities.Product;

namespace VVGames.BusinessLogic.Interface
{
    public interface IBasket
    {
        List<Basket> GetAllProduct(int userId);
        void AddProduct(int userId, int productId, int countProduct);
        void UpdateProduct(int userId, int productId, int countProduct);
        void RemoveProduct(int userId, int productId);
        void RemoveAll(int userId);
    }
}
