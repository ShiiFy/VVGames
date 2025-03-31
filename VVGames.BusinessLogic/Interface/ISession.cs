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
        bool IsAuthenticated(int userId); //проверка зарегистрирован ли пользователь
        UUsers GetCurrentUser(int userId); //получение информации о пользователе
        bool ChangePassword(int userId, string oldPassword, string newPassword); //Сменя пароля

    }
}
