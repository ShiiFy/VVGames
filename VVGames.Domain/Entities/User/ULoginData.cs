using System;

namespace VVGames.Domain.Entities.User
{
    public class ULoginData
    {
        public string Credential { get; set; } // Имя пользователя или email
        public string Password { get; set; } //Пароль
        public string LoginIp { get; set; } //ID пользователя
        public DateTime LoginDateTime { get; set; }//Время входа
    }
}
