using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVGames.Domain.Entities.User
{
    public class URegistrData
    {
        public string UserName { get; set; } //Имя пользователя
        public string Name { get; set; } //Имя 
        public string UserEmail { get; set; } //Email пользователя
        public string Password { get; set; } //Пароль
        public string LoginIp { get; set; } //ID пользователя
        public DateTime LoginDateTime { get; set; } //Время регистрации
    }
}
