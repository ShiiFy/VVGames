using System;

namespace VVGames.Domain.Entities.User
{
    public class URegistrData
    {
        public string Username { get; set; } //Имя пользователя
        public string Name { get; set; } //Имя 
        public string Email { get; set; } //Email пользователя
        public string PhoneNumber { get; set; } //Номер телефона
        public string Password { get; set; } //Пароль
        public string LoginIp { get; set; } //ID пользователя
        public DateTime LoginDateTime { get; set; } //Время регистрации
    }
}
