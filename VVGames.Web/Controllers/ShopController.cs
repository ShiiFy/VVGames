using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using VVGames.BusinessLogic.BL;
using VVGames.Domain.Entities.Product;
using VVGames.Web.Models;

namespace VVGames.Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly ProductBL _productBL = new ProductBL();

        [HttpGet]
        public ActionResult Call_of_Duty() => View();

        [HttpGet]
        public ActionResult Civilithation() => View();

        [HttpGet]
        public ActionResult Helldivers_2() => View();

        [HttpGet]
        public ActionResult Hearts_of_Iron_IV() => View();

        [HttpGet]
        public ActionResult Oblivion() => View();

        [HttpGet]
        public ActionResult Kingdom() => View();

        [HttpGet]
        public ActionResult Warhammer() => View();

        [HttpGet]
        public ActionResult NBA_K25() => View();

        [HttpGet]
        public ActionResult Rust() => View();

        [HttpGet]
        public ActionResult Forza_Horizon_5() => View();

        [HttpGet]
        public ActionResult Schedule() => View();

        [HttpGet]
        public ActionResult Stone_Simulator() => View();

        [HttpGet]
        public ActionResult Shop(int page = 1)
        {
            int pageSize = 12;

            var games = _productBL.GetGamesPaged(page, pageSize);
            int totalItems = _productBL.GetTotalGameCount();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var viewModel = games.Select(g => new GameViewModel
            {
                Id = g.Id,
                Articul = g.Articul,
                Name = g.Name,
                Genres = g.Genres.ToString(),
                Price = g.Price,
                ImageUrl = g.ImageUrl
            }).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var game = _productBL.GetGameById(id);
            if (game == null)
                return RedirectToAction("Shop");

            var viewModel = new GameDetailsViewModel
            {
                Id = game.Id,
                Articul = game.Articul,
                Name = game.Name,
                Genres = game.Genres.ToString(),
                Price = game.Price,
                ImageUrl = game.ImageUrl,
                ShortDescription = game.ShortDescription,
                Description = game.Description,
                ReleaseDate = game.ReleaseDate
            };

            return View(viewModel);
        }
    }

}