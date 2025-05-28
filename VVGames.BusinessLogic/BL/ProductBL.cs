using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.BusinessLogic.Core;
using VVGames.BusinessLogic.DBModel;
using VVGames.BusinessLogic.Interface;
using VVGames.Domain.Entities.Product;

namespace VVGames.BusinessLogic.BL
{
    public class ProductBL : ProductApi, IProduct
    {

        public bool AddProduct(DBGames model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) || model.Price <= 0)
                return false;

            if (ArticulExistsAction(model.Articul))
                return false;

            AddGameAction(model); 
            return true;
        }
        public List<DBGames> GetGames()
        {
            return GetAllGamesAction();
        }
        public bool UpdateProduct(DBGames updatedData)
        {
            var game = GetGameByIdAction(updatedData.Id);
            if (game == null)
                return false;

            if (string.IsNullOrWhiteSpace(updatedData.Name) || updatedData.Price <= 0)
                return false;

            game.Articul = updatedData.Articul;
            game.Name = updatedData.Name;
            game.Genres = updatedData.Genres;
            game.Price = updatedData.Price;
            game.ImageUrl = updatedData.ImageUrl;
            game.Description = updatedData.Description;
            game.ReleaseDate = updatedData.ReleaseDate;

            SaveGameChangesAction(game);
            return true;
        }
        public bool DeleteGame(int id)
        {
            var game = GetGameByIdAction(id);
            if (game == null)
                return false;

            DeleteGameByIdAction(id);
            return true;
        }
        public DBGames GetGameById(int id) => GetGameByIdAction(id);
        public List<DBGames> GetGamesPaged(int page, int pageSize) => GetGamesPagedAction(page, pageSize);
        public int GetTotalGameCount() => GetTotalGameCountAction();
    }
}
