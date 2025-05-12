using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VVGames.Domain.Entities.User
{
    public class UUsers
    {
        public int Id { get; set; } //ID пользователя
        public string Username { get; set; } //Имя пользователя
        public string Name { get; set; } //Имя 
        public string Email { get; set; } //Email пользователя
        public string PhoneNumber { get; set; } //Номер пользователя
        public string Role { get; set; } //Роль пользователя
        public DateTime LoginDateTime { get; set; } //Время регистрации
        public DateTime LastDateTime { get; set; } //Время последнего входа
    }
}
