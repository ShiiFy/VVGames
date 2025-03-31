using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
