using System.Collections.Generic;
using VVGames.Domain.Entities.Product;

namespace VVGames.BusinessLogic.Interface
{
    public interface IProduct
    {
        bool AddProduct(DBGames model); //Добавления игры
        List<DBGames> GetGames(); //Получение списка всех игр
        bool UpdateProduct(DBGames updatedData); //Обновление данных игры
        bool DeleteGame(int id); //Удаление игры
        DBGames GetGameById(int id); //Получение игры по айди
        List<DBGames> GetGamesPaged(int page, int pageSize); //
        int GetTotalGameCount(); //
    }
}