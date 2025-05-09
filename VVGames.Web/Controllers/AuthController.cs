using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VVGames.BusinessLogic.DBModel;
using VVGames.Domain.Entities.Product;
using VVGames.Domain.Entities.User;

namespace VVGames.Web.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Sing()
        {
            return View();
        }
        public ActionResult Reg()
        {
            var user = new DBUser
            {
                Email = "solokuzmin@gmail.com",
                LastDateTime = DateTime.Now,
                LoginDateTime = DateTime.Now,
                Username = "ShiFy",
                Password = "1q2w3e4r"
            };
            using (var db = new UserContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            return View();
        }
        public ActionResult Profile()

        {
            return View();
        }


    }
}