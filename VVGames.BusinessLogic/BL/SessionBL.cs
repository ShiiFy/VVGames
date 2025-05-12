using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.BusinessLogic.Core;
using VVGames.BusinessLogic.DBModel;
using VVGames.BusinessLogic.Interface;
using VVGames.Domain.Entities.User;
using VVGames.Domain.Enums;
using VVGames.Helper;

namespace VVGames.BusinessLogic.BL
{
    public class SessionBL : UserApi, ISession
    {
        public ULoginSuccess Login(ULoginData loginData)
        {
            var result = new ULoginSuccess();

            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u =>
                    u.Username.Equals(loginData.Credential, StringComparison.OrdinalIgnoreCase) ||
                    u.Email.Equals(loginData.Credential, StringComparison.OrdinalIgnoreCase));

                if (user == null)
                {
                    result.Success = false;
                    result.CredentialSuccess = false;
                    result.PasswordSuccess = false;
                    result.Message = "Пользователь не найден.";
                    return result;
                }

                result.CredentialSuccess = true;

                if (!PasswordHelper.VerifyPassword(loginData.Password, user.PasswordHash))
                {
                    result.Success = false;
                    result.PasswordSuccess = false;
                    result.Message = "Неверный пароль.";
                    return result;
                }

                user.LastDateTime = DateTime.Now;
                db.SaveChanges();

                result.Success = true;
                result.UserId = user.Id;
                result.Username = user.Username;
                result.Role = user.Level.ToString();
                result.PasswordSuccess = true;
                result.Message = "Вход выполнен успешно.";
                return result;
            }
        }
        public URegistrSuccess Register(URegistrData registrData)
        {
            var result = new URegistrSuccess();

            using (var db = new UserContext())
            {
                if (db.Users.Any(u => u.Username == registrData.Username))
                {
                    result.Success = false;
                    result.UserNameSuccess = false;
                    result.EmailSuccess = true;
                    result.Message = "Пользователь с таким логином уже существует.";
                    return result;
                }

                if (db.Users.Any(u => u.Email == registrData.Email))
                {
                    result.Success = false;
                    result.UserNameSuccess = true;
                    result.EmailSuccess = false;
                    result.Message = "Email уже зарегистрирован.";
                    return result;
                }

                var passwordHash = PasswordHelper.HashPassword(registrData.Password);

                var newUser = new DBUser
                {
                    Username = registrData.Username,
                    Email = registrData.Email,
                    PasswordHash = passwordHash,
                    Name = registrData.Name,
                    PhoneNumber = registrData.PhoneNumber,
                    Level = URole.User,
                    LoginDateTime = DateTime.Now,
                    LastDateTime = DateTime.Now
                };

                db.Users.Add(newUser);
                db.SaveChanges();

                result.Success = true;
                result.UserNameSuccess = true;
                result.EmailSuccess = true;
                result.Message = "Регистрация прошла успешно.";
                return result;
            }
        }
        public bool IsAuthenticated(int userId)
        {
            using (var db = new UserContext())
                return db.Users.Any(u => u.Id == userId);
        }
        public UUsers GetCurrentUser(int userId)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null) return null;

                return new UUsers
                {
                    Id = user.Id,
                    Username = user.Username,
                    Name = user.Name,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Role = user.Level.ToString(),
                    LoginDateTime = user.LoginDateTime,
                    LastDateTime = user.LastDateTime
                };
            }
        }
        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null) return false;

                if (!PasswordHelper.VerifyPassword(oldPassword, user.PasswordHash))
                    return false;

                user.PasswordHash = PasswordHelper.HashPassword(newPassword);
                db.SaveChanges();
                return true;
            }
        }
        public bool UpdateUser(int userId, UUserUpdate update)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                    return false;

                // Проверка текущего пароля
                if (!PasswordHelper.VerifyPassword(update.CurrentPassword, user.PasswordHash))
                    return false;

                // Обновляем только если поле не пустое и изменилось
                if (!string.IsNullOrWhiteSpace(update.Username) && update.Username != user.Username)
                    user.Username = update.Username;

                if (!string.IsNullOrWhiteSpace(update.Name) && update.Name != user.Name)
                    user.Name = update.Name;

                if (!string.IsNullOrWhiteSpace(update.Email) && update.Email != user.Email)
                    user.Email = update.Email;

                if (!string.IsNullOrWhiteSpace(update.PhoneNumber) && update.PhoneNumber != user.PhoneNumber)
                    user.PhoneNumber = update.PhoneNumber;

                // Смена пароля (если указан новый и он подтверждён)
                if (!string.IsNullOrWhiteSpace(update.NewPassword) &&
                    update.NewPassword == update.ConfirmPassword)
                {
                    user.PasswordHash = PasswordHelper.HashPassword(update.NewPassword);
                }

                db.SaveChanges();
                return true;
            }
        }

    }
}
