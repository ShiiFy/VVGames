using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using VVGames.BusinessLogic.Core;
using VVGames.BusinessLogic.DBModel;
using VVGames.BusinessLogic.Interface;
using VVGames.Domain.Entities.Basket;
using VVGames.Domain.Entities.Product;

namespace VVGames.BusinessLogic.BL
{
    public class BasketBL : BasketApi, IBasket
    {
        private readonly IProduct _productBL;
        public BasketBL(BasketContext ctx, IProduct productBL)
        : base(ctx)
        {
            _productBL = productBL;
        }
        public List<Basket> GetAllProduct(int userId)
        {
            return GetByUserAction(userId)
                .Select(entry =>
                {
                    var game = _productBL.GetGameById(entry.ProductId);
                    if (game == null) return null;
                    return new Basket
                    {
                        ProductId = game.Id,
                        Name = game.Name,
                        ImageUrl = game.ImageUrl,
                        UnitPrice = game.Price,
                        Quantity = entry.Quantity
                    };
                })
                .Where(dto => dto != null)
                .ToList();
        }
        public void AddProduct(int userId, int productId, int countProduct)
        {
            var entry = GetByUserAction(userId).FirstOrDefault(b => b.ProductId == productId);

            if (entry != null)
            {
                entry.Quantity += countProduct;
            }
            else
            {
                AddAction(new DBBasket
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = countProduct
                });
            }

            SaveAction(); 
        }
        public void UpdateProduct(int userId, int productId, int countProduct)
        {
            var entry = GetByUserAction(userId).FirstOrDefault(b => b.ProductId == productId);

            if (entry == null)
            {
                if (countProduct > 0)
                {
                    AddAction(new DBBasket
                    {
                        UserId = userId,
                        ProductId = productId,
                        Quantity = countProduct
                    });
                }
            }
            else
            {
                if (countProduct > 0)
                {
                    entry.Quantity = countProduct;
                }
                else
                {
                    RemoveAction(entry);
                }
            }

            SaveAction();
        }
        public void RemoveProduct(int userId, int productId)
        {
            var entry = GetByUserAction(userId).FirstOrDefault(b => b.ProductId == productId);

            if (entry != null)
            {
                RemoveAction(entry);
                SaveAction();
            }
        }
        public void RemoveAll(int userId)
        {
            var entries = GetByUserAction(userId).ToList();
            foreach (var entry in entries)
                RemoveAction(entry);

            SaveAction();
        }
    }
}
