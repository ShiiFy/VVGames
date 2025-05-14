using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.Domain.Entities.Product;

namespace VVGames.BusinessLogic.Interface
{
    public interface IBasket
    {
        List<Games> GetAllProduct(int userId); // получить список товаров пользователя
        void AddProduct(int userId, int productId, int countProduct); // добавить товар(или увеличить)
        void UpdateProduct(int userId, int productId, int countProduct); // изменить количество вручную
        void RemoveProduct(int userId, int productId); // удалить один товар
        void RemoveAll(int userId); // очистить всю корзину
    }
}
