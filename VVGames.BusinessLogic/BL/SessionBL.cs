using System;
using VVGames.BusinessLogic.Core;
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

            var user = GetUserByCredentialAction(loginData.Credential); 

            if (user == null)
            {
                result.Success = false;
                result.CredentialSuccess = false;
                result.PasswordSuccess = false;
                result.Message = "Пользователь не найден.";
                return result;
            }

            result.CredentialSuccess = true;

            if (user.IsBlocked)
            {
                result.Success = false;
                result.PasswordSuccess = false;
                result.Message = "Ваш аккаунт заблокирован.";
                return result;
            }

            if (!PasswordHelper.VerifyPassword(loginData.Password, user.PasswordHash))
            {
                result.Success = false;
                result.PasswordSuccess = false;
                result.Message = "Неверный пароль.";
                return result;
            }

            UpdateLastLoginAction(user.Id);

            result.Success = true;
            result.UserId = user.Id;
            result.Username = user.Username;
            result.Role = user.Level.ToString();
            result.PasswordSuccess = true;
            result.Message = "Вход выполнен успешно.";

            return result;
        }
        public URegistrSuccess Register(URegistrData registrData)
        {
            var result = new URegistrSuccess();

            if (UsernameExistsAction(registrData.Username))
            {
                result.Success = false;
                result.UserNameSuccess = false;
                result.EmailSuccess = true;
                result.Message = "Пользователь с таким логином уже существует.";
                return result;
            }

            if (EmailExistsAction(registrData.Email))
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

            AddUserAction(newUser);

            result.Success = true;
            result.UserNameSuccess = true;
            result.EmailSuccess = true;
            result.Message = "Регистрация прошла успешно.";
            return result;
        }
        public UUsers GetCurrentUser(int userId)
        {
            var user = GetUserByIdAction(userId);

            if (user == null)
                return null;

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
        public bool UpdateUser(int userId, UUserUpdate update)
        {
            var user = GetUserByIdAction(userId);
            if (user == null)
                return false;

            // Проверка текущего пароля
            if (!PasswordHelper.VerifyPassword(update.CurrentPassword, user.PasswordHash))
                return false;

            // Обновление данных
            if (!string.IsNullOrWhiteSpace(update.Username) && update.Username != user.Username)
                user.Username = update.Username;

            if (!string.IsNullOrWhiteSpace(update.Name) && update.Name != user.Name)
                user.Name = update.Name;

            if (!string.IsNullOrWhiteSpace(update.Email) && update.Email != user.Email)
                user.Email = update.Email;

            if (!string.IsNullOrWhiteSpace(update.PhoneNumber) && update.PhoneNumber != user.PhoneNumber)
                user.PhoneNumber = update.PhoneNumber;

            // Обновление пароля
            if (!string.IsNullOrWhiteSpace(update.NewPassword) && update.NewPassword == update.ConfirmPassword)
                user.PasswordHash = PasswordHelper.HashPassword(update.NewPassword);

            SaveUserChangesAction(user);
            return true;
        }
    }
}
