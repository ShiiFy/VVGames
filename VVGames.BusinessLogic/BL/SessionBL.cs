using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.BusinessLogic.Core;
using VVGames.BusinessLogic.Interface;
using VVGames.Domain.Entities.User;

namespace VVGames.BusinessLogic.BL
{
    public class SessionBL : UserApi, ISession
    {
        public ULoginSuccess Login(ULoginData loginData)
        {
            throw new NotImplementedException();
        }
        public URegistrSuccess Register(URegistrData registrData)
        {
            throw new NotImplementedException();
        }
        public bool IsAuthenticated(int userId)
        {
            throw new NotImplementedException();
        }
        public UUsers GetCurrentUser(int userId)
        {
            throw new NotImplementedException();
        }
        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
