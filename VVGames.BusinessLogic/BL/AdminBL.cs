using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.BusinessLogic.Core;
using VVGames.BusinessLogic.Interface;
using VVGames.Domain.Entities.User;
using VVGames.Domain.Enums;

namespace VVGames.BusinessLogic.BL
{
    public class AdminBL : AdminApi, IAdmin
    {
        public List<UUsers> GetAllUsers()
        {
            var dbUsers = GetAllRawUsersAction();

            return dbUsers.Select(u => new UUsers
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                IsBlocked = u.IsBlocked,
                Name = u.Name,
                Role = u.Level.ToString(),
                LoginDateTime = u.LoginDateTime,
                LastDateTime = u.LastDateTime
            }).ToList();
        }
        public bool ToggleUserBlock(int userId)
        {
            var user = GetUserByIdAction(userId);
            if (user == null || user.Level == URole.SuperAdmin)
                return false;

            ToggleBlockAction(user);
            return true;
        }
        public bool ToggleUserRole(int userId)
        {
            var user = GetUserByIdAction(userId);

            if (user == null || user.Level == URole.SuperAdmin)
                return false;

            ToggleRoleAction(user);
            return true;
        }
    }
}
