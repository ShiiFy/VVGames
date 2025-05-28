using System.Collections.Generic;
using System.Linq;
using VVGames.BusinessLogic.DBModel;
using VVGames.Domain.Entities.User;
using VVGames.Domain.Enums;

namespace VVGames.BusinessLogic.Core
{
    public class AdminApi : BaseUserApi
    {
        protected List<DBUser> GetAllRawUsersAction()
        {
            using (var db = new UserContext())
                return db.Users.ToList();
        }
        protected void ToggleBlockAction(DBUser user)
        {
            user.IsBlocked = !user.IsBlocked;
            SaveUserChangesAction(user); 
        }
        protected void ToggleRoleAction(DBUser user)
        {
            if (user.Level == URole.Admin)
                user.Level = URole.User;
            else if (user.Level == URole.User)
                user.Level = URole.Admin;

            SaveUserChangesAction(user); 
        }

    }
}
