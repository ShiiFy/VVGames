using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.Domain.Entities.Product;

namespace VVGames.BusinessLogic.Interface
{
    public interface IProduct
    {
        bool AddGame(DBGames model); //Добавления игры
        List<DBGames> GetGames(); //Получение списка всех игр
        bool UpdateGame(DBGames updatedData); //Обновление данных игры
        bool DeleteGame(int id); //Удаление игры
        DBGames GetGameById(int id); //Получение игры по айди
    }
}
