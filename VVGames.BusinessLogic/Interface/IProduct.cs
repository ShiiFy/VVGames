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
        bool AddProduct(DBGames model); //Добавления игры
        List<DBGames> GetGames(); //Получение списка всех игр
        bool UpdateProduct(DBGames updatedData); //Обновление данных игры
        bool DeleteGame(int id); //Удаление игры
        DBGames GetGameById(int id); //Получение игры по айди
    }
}
