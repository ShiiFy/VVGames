using VVGames.BusinessLogic.BL;
using VVGames.BusinessLogic.DBModel;
using VVGames.BusinessLogic.Interface;

namespace VVGames.BusinessLogic
{
    public class BusinesLogic
    {
        public ISession GetSessiionBL()
        {
            return new SessionBL();
        }
        public IAdmin GetAdminBL()
        {
            return new AdminBL();
        }
        public IProduct GetProductBL()
        {
            return new ProductBL();
        }
        public IBasket GetBasketBL()
        {
            var context = new BasketContext();
            var productBL = GetProductBL();
            return new BasketBL(context, productBL);
        }
    }
}
