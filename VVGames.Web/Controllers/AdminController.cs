using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VVGames.BusinessLogic.BL;
using VVGames.Domain.Entities.Product;
using VVGames.Web.Filters;

namespace VVGames.Web.Controllers
{
    [Admins]
    public class AdminController : Controller
    {
        private readonly AdminBL _adminBL = new AdminBL();

        [HttpGet]
        public ActionResult Dashboard() => View(); 

        [HttpGet]
        public ActionResult UserManagement()
        {
            var users = _adminBL.GetAllUsers(); 
            return View(users); 
        }

        [HttpPost]
        public ActionResult ToggleBlock(int userId)
        {
            var success = _adminBL.ToggleUserBlock(userId);
            if (!success)
            {
                TempData["Message"] = "Ошибка при блокировке.";
            }

            return RedirectToAction("UserManagement");
        }

        [HttpPost]
        public ActionResult ToggleAdmin(int userId)
        {
            var success = _adminBL.ToggleUserRole(userId);

            if (!success)
            {
                TempData["Message"] = "Ошибка при изменении роли.";
            }

            return RedirectToAction("UserManagement");
        }

        [HttpGet]
        public ActionResult ProductManagement()
        {
            var games = _adminBL.GetAllGames();
            return View(games);
        }

        [HttpGet]
        public ActionResult AddGame() => View(new DBGames());

        [HttpPost]
        public ActionResult AddGame(DBGames model, int[] SelectedGenres, HttpPostedFileBase imageFile)
        {
            var success = _adminBL.AddGame(model, SelectedGenres, imageFile);

            if (!success)
            {
                ModelState.AddModelError("", "Ошибка при добавлении. Возможно, артикул уже существует или данные некорректны.");
                return View(model);
            }

            return RedirectToAction("ProductManagement");
        }

        [HttpPost]
        public ActionResult DeleteGame(int id)
        {
            var success = _adminBL.DeleteGame(id);

            if (!success)
                TempData["Message"] = "Ошибка при удалении игры.";
            else
                TempData["Message"] = "Игра удалена.";

            return RedirectToAction("ProductManagement");
        }

        [HttpGet]
        public ActionResult EditGame(int id)
        {
            var game = _adminBL.GetGame(id);
            if (game == null)
                return RedirectToAction("ProductManagement");

            return View(game);
        }

        [HttpPost]
        public ActionResult EditGame(DBGames model, int[] SelectedGenres, HttpPostedFileBase imageFile)
        {
            var success = _adminBL.UpdateGame(model, SelectedGenres, imageFile);

            if (!success)
            {
                ModelState.AddModelError("", "Ошибка при обновлении товара.");
                return View(model);
            }

            return RedirectToAction("ProductManagement");
        }
    }
}