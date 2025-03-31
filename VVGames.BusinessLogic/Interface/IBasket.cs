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
        List<Games> GetAllProduct(int UserID);
        void AddProduct(int UserID, int ProductID, int countProduct);
        void UpdateProduct(int UserID, int ProductID, int countProduct);
        void RemoveProduct(int UserID, int ProductID);
        void RemoveAll(int UserID);
    }
}
