using System;
using System.Linq;
using System.Web.Mvc;
using VVGames.BusinessLogic;
using VVGames.BusinessLogic.Interface;
using VVGames.Web.Models;

namespace VVGames.Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProduct _productBL;

        public ShopController()
        {
            var logic = new BusinesLogic();
            _productBL = logic.GetProductBL();
        }

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
    
           public ActionResult Search(string query, int page = 1)
        {
            const int PageSize = 6;

            var filteredGames = _productBL.SearchGames(query);

            var totalItems = filteredGames.Count;
            var gamesToShow = filteredGames
                              .Skip((page - 1) * PageSize)
                              .Take(PageSize)
                              .ToList();

            var viewModel = gamesToShow.Select(game => new GameViewModel
            {
                Id = game.Id,
                Articul = game.Articul,
                Name = game.Name,
                Genres = game.Genres.ToString(),
                Price = game.Price,
                ImageUrl = game.ImageUrl,
                ShortDescription = game.ShortDescription
            }).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);
            ViewBag.SearchQuery = query;

            return View("Shop", viewModel);   // переиспользуем уже существующую вёрстку
           }

    }

}