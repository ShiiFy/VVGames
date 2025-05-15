using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VVGames.BusinessLogic.BL;
using VVGames.BusinessLogic.DBModel;
using VVGames.BusinessLogic.Interface;
using VVGames.Domain.Entities.Basket;
using VVGames.Web.Filters;
using VVGames.Web.Models;

namespace VVGames.Web.Controllers
{
    [Users]
    public class BasketController : Controller
    {
        private readonly IBasket _basket;
        public BasketController()
        : this(
            new BasketBL(
                new BasketContext(),
                new ProductBL()
            )
          )
        {
        }
        public BasketController(IBasket basket)
        {
            _basket = basket;
        }
        public ActionResult Basket()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Login", "Account");

            int userId = (int)Session["UserId"];
            List<Basket> dtos = _basket.GetAllProduct(userId);

            var vm = dtos.Select(d => new BasketItemViewModel
            {
                ProductId = d.ProductId,
                Name = d.Name,
                ImageUrl = d.ImageUrl,
                UnitPrice = d.UnitPrice,
                Quantity = d.Quantity
            })
            .ToList();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Add(int productId, int quantity = 1)
        {
            int userId = (int)Session["UserId"];
            _basket.AddProduct(userId, productId, quantity);
            return RedirectToAction("Basket");
        }

        [HttpPost]
        public ActionResult Remove(int productId)
        {
            int userId = (int)Session["UserId"];
            _basket.RemoveProduct(userId, productId);
            return RedirectToAction("Basket");
        }

        [HttpPost]
        public ActionResult Clear()
        {
            int userId = (int)Session["UserId"];
            _basket.RemoveAll(userId);
            return RedirectToAction("Basket");
        }

        [HttpPost]
        public ActionResult Update(int productId, int quantity)
        {
            int userId = (int)Session["UserId"];
            _basket.UpdateProduct(userId, productId, quantity);
            return RedirectToAction("Basket");
        }
    }
}