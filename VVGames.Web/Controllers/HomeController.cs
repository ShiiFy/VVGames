using System.Web.Mvc;
using VVGames.Web.Filters;

namespace VVGames.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();
        public ActionResult Contact() => View();

        [Users]
        public ActionResult Wheel() =>View();

    }
}