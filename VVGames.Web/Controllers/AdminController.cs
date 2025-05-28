using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VVGames.BusinessLogic.BL;
using VVGames.Domain.Entities.Product;
using VVGames.Web.Filters;
using VVGames.Web.Models;

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

            var model = users.Select(u => new UserTableItemViewModel
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Role = u.Role,
                LastDateTime = u.LastDateTime,
                IsBlocked = u.IsBlocked
            }).ToList();

            return View(model); 
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
            var dbGames = _adminBL.GetAllGames();

            var viewModel = dbGames.Select(g => new GameTableItemViewModel
            {
                Id = g.Id,
                Articul = g.Articul,
                Name = g.Name,
                Price = g.Price,
                Genres = g.Genres.ToString(),
                ReleaseDate = g.ReleaseDate,
                ImageUrl = g.ImageUrl
            }).ToList();

            return View(dbGames);
        }

        [HttpGet]
        public ActionResult AddGame() => View(new DBGames());

        [HttpPost]
        public ActionResult AddGame(AddGameViewModel model)
        {
            var dbModel = new DBGames
            {
                Articul = model.Articul,
                Name = model.Name,
                ShortDescription = model.ShortDescription,
                Price = model.Price,
                Description = model.Description,
                ReleaseDate = model.ReleaseDate,
            };

            var success = _adminBL.AddGame(dbModel, model.SelectedGenres?.ToArray(), model.ImageFile);

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
        public ActionResult EditGame(EditGameViewModel model, int[] SelectedGenres, HttpPostedFileBase imageFile)
        {
            var dbModel = new DBGames
            {
                Id = model.Id,
                Articul = model.Articul,
                Name = model.Name,
                ShortDescription = model.ShortDescription,
                Price = model.Price,
                Description = model.Description,
                ReleaseDate = model.ReleaseDate,
            };

            var success = _adminBL.UpdateGame(dbModel, SelectedGenres ?? new int[0], imageFile);

            if (!success)
            {
                ModelState.AddModelError("", "Ошибка при обновлении товара.");
                return View(model);
            }

            return RedirectToAction("ProductManagement");
        }
    }
}