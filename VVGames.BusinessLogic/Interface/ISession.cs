using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.Domain.Entities.User;

namespace VVGames.BusinessLogic.Interface
{
    public interface ISession
    {
        ULoginSuccess Login(ULoginData loginData); //Вход пользователя
        URegistrSuccess Register(URegistrData registrData); //Регистрация пользователя
        UUsers GetCurrentUser(int userId); //получение информации о пользователей
        bool UpdateUser(int userId, UUserUpdate update); //Обновление данных
    }
}
