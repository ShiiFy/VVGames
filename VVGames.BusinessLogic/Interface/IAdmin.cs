using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VVGames.BusinessLogic.BL;
using VVGames.Domain.Entities.Product;
using VVGames.Domain.Entities.User;

namespace VVGames.BusinessLogic.Interface
{
    public interface IAdmin
    {
        //Функции для работы с пользователями
        List<UUsers> GetAllUsers(); //Получиние списка пользователей
        bool ToggleUserBlock(int userId); //Изменение блокировки пользователя
        bool ToggleUserRole(int userId); //Изменение роли пользовател


        //Функции для работы с продуктами
        bool AddGame(DBGames model, int[] selectedGenres, HttpPostedFileBase imageFile); //Добавления игры
        bool DeleteGame(int id); //Удаление игры
        List<DBGames> GetAllGames(); //Получение списка всех игр
        DBGames GetGame(int id); //Получение игры по айди
        bool UpdateGame(DBGames model, int[] selectedGenres, HttpPostedFileBase imageFile); //Обновление данных игры
    }
}
