using System;
using System.Web;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.BusinessLogic.Core;
using VVGames.BusinessLogic.Interface;
using VVGames.Domain.Entities.Product;
using VVGames.Domain.Entities.User;
using VVGames.Domain.Enums;

namespace VVGames.BusinessLogic.BL
{
    public class AdminBL : AdminApi, IAdmin
    {
        //Функции для работы с пользователями
        public List<UUsers> GetAllUsers()
        {
            var dbUsers = GetAllRawUsersAction();

            return dbUsers.Select(u => new UUsers
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                IsBlocked = u.IsBlocked,
                Name = u.Name,
                Role = u.Level.ToString(),
                LoginDateTime = u.LoginDateTime,
                LastDateTime = u.LastDateTime
            }).ToList();
        }
        public bool ToggleUserBlock(int userId)
        {
            var user = GetUserByIdAction(userId);
            if (user == null || user.Level == URole.SuperAdmin)
                return false;

            ToggleBlockAction(user);
            return true;
        }
        public bool ToggleUserRole(int userId)
        {
            var user = GetUserByIdAction(userId);

            if (user == null || user.Level == URole.SuperAdmin)
                return false;

            ToggleRoleAction(user);
            return true;
        }

        //Функции для работы с продуктами
        private readonly ProductBL _productBL = new ProductBL();
        public bool AddGame(DBGames model, int[] selectedGenres, HttpPostedFileBase imageFile)
        {
            model.Genres = GameGenre.None;
            if (selectedGenres != null)
            {
                foreach (var g in selectedGenres)
                    model.Genres |= (GameGenre)g;
            }

            if (imageFile != null && imageFile.ContentLength > 0)
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var folderPath = HttpContext.Current.Server.MapPath("~/Content/images/games/");
                Directory.CreateDirectory(folderPath);

                var savePath = Path.Combine(folderPath, fileName);
                imageFile.SaveAs(savePath);

                model.ImageUrl = "/Content/images/games/" + fileName;
            }

            model.ShortDescription = model.ShortDescription?.Trim();
            model.Description = model.Description?.Trim();

            return _productBL.AddGame(model);
        }
        public bool DeleteGame(int id) => _productBL.DeleteGame(id);
        public List<DBGames> GetAllGames() => _productBL.GetGames();
        public DBGames GetGame(int id) => _productBL.GetGameById(id);
        public bool UpdateGame(DBGames model, int[] selectedGenres, HttpPostedFileBase imageFile)
        {
            var existingGame = _productBL.GetGameById(model.Id);
            if (existingGame == null)
                return false;

            model.Genres = GameGenre.None;
            if (selectedGenres != null)
            {
                foreach (var g in selectedGenres)
                    model.Genres |= (GameGenre)g;
            }
            else
            {
                model.Genres = existingGame.Genres;
            }

            // Если новое изображение не загружено — оставить старое
            if (imageFile == null || imageFile.ContentLength == 0)
            {
                model.ImageUrl = existingGame.ImageUrl;
            }
            else
            {
                var fileName = Path.GetFileName(imageFile.FileName);
                var folderPath = HttpContext.Current.Server.MapPath("~/Content/images/games/");
                Directory.CreateDirectory(folderPath);

                var savePath = Path.Combine(folderPath, fileName);
                imageFile.SaveAs(savePath);

                model.ImageUrl = "/Content/images/games/" + fileName;
            }

            // Если поле не изменено — подставляем из базы
            model.Articul = string.IsNullOrWhiteSpace(model.Articul) ? existingGame.Articul : model.Articul;
            model.Name = string.IsNullOrWhiteSpace(model.Name) ? existingGame.Name : model.Name;
            model.ShortDescription = string.IsNullOrWhiteSpace(model.ShortDescription) ? existingGame.ShortDescription : model.ShortDescription.Trim();
            model.Description = string.IsNullOrWhiteSpace(model.Description) ? existingGame.Description : model.Description;
            model.ReleaseDate = model.ReleaseDate == default ? existingGame.ReleaseDate : model.ReleaseDate;
            model.Price = model.Price <= 0 ? existingGame.Price : model.Price;

            return _productBL.UpdateGame(model);
        }

    }
}
