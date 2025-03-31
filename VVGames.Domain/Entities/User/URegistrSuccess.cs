using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVGames.Domain.Entities.User
{
    public class URegistrSuccess
    {
        public bool Success { get; set; } // Результат регистрации
        public bool UserNameSuccess { get; set; } // Проверка не зарегистрирован ли пользователь с таким username-ом
        public bool EmailSuccess { get; set; } // Проверка не зарегистрирован ли пользователь с этим email-ом
        public string Message { get; set; } // Сообщение для пользователя
    }
}
