using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VVGames.BusinessLogic.DBModel;
using VVGames.Web.Filters;

namespace VVGames.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();
        public ActionResult Shop() => View();
        public ActionResult Contact() => View();
        public ActionResult Wheel() =>View();

        [Users]
        public ActionResult Basket() => View();

    }
}