using System;
using System.Linq;
using VVGames.BusinessLogic.DBModel;
using VVGames.Domain.Entities.User;

namespace VVGames.BusinessLogic.Core
{
    public class UserApi : BaseUserApi
    {
        protected DBUser GetUserByCredentialAction(string credential)
        {
            using (var db = new UserContext())
            {
                return db.Users.FirstOrDefault(u =>
                    u.Username.Equals(credential, StringComparison.OrdinalIgnoreCase) ||
                    u.Email.Equals(credential, StringComparison.OrdinalIgnoreCase));
            }
        }
        protected void UpdateLastLoginAction(int userId)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.LastDateTime = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }
        protected void UpdateUserPasswordAction(int userId, string newPasswordHash)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.PasswordHash = newPasswordHash;
                    db.SaveChanges();
                }
            }
        }
    }
}
