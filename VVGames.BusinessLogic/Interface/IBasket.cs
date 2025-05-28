using System.Collections.Generic;
using VVGames.Domain.Entities.Basket;

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
