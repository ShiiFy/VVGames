using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVGames.BusinessLogic.BL;
using VVGames.BusinessLogic.DBModel;
using VVGames.BusinessLogic.Interface;
using VVGames.Domain.Entities.Basket;

namespace VVGames.BusinessLogic
{
    public class BussinesLogic
    {
        public ISession GetSessiionBL()
        {
            return new SessionBL();
        }
        public IAdmin GetAdminBL()
        {
            return new AdminBL();
        }
    }
}
