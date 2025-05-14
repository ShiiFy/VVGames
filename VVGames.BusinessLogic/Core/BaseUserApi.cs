using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.BusinessLogic.DBModel;
using VVGames.Domain.Entities.User;

namespace VVGames.BusinessLogic.Core
{
    public class BaseUserApi
    {
        protected DBUser GetUserByIdAction(int userId)
        {
            using (var db = new UserContext())
                return db.Users.FirstOrDefault(u => u.Id == userId);
        }
        protected bool IsUserExistsAction(int userId)
        {
            using (var db = new UserContext())
                return db.Users.Any(u => u.Id == userId);
        }
        protected void SaveUserChangesAction(DBUser user)
        {
            using (var db = new UserContext())
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        protected void AddUserAction(DBUser user)
        {
            using (var db = new UserContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
        protected bool UsernameExistsAction(string username)
        {
            using (var db = new UserContext())
                return db.Users.Any(u => u.Username == username);
        }
        protected bool EmailExistsAction(string email)
        {
            using (var db = new UserContext())
                return db.Users.Any(u => u.Email == email);
        }
    }
}
