using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVGames.Domain.Entities.User
{
    public class ULoginSuccess
    {
        public bool Success { get; set; } // Результат входа
        public bool CredentialSuccess { get; set; } // Проверка зарегистрирован ли пользователь по username или email
        public bool PasswordSuccess { get; set; } // Проверка пароля
        public string Message { get; set; } // Сообщение для пользователя
    }
}
