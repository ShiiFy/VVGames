using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using VVGames.BusinessLogic.BL;

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

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(games);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var game = _productBL.GetGameById(id);
            if (game == null)
                return RedirectToAction("Shop");

            return View(game);
        }
    }

}