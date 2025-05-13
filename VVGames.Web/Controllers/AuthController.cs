using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VVGames.BusinessLogic.BL;
using VVGames.BusinessLogic.DBModel;
using VVGames.Domain.Entities.Product;
using VVGames.Domain.Entities.User;
using VVGames.Domain.Enums;

namespace VVGames.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly SessionBL _sessionBL = new SessionBL();
        // GET: Auth
        [HttpGet]
        public ActionResult Reg() => View();

        [HttpPost]
        public ActionResult Reg(string username, string email, string password, string name, string telephone, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.Message = "Пароли не совпадают.";
                return View();
            }

            var data = new URegistrData
            {
                Username = username,
                Email = email,
                Password = password,
                Name = name,               
                PhoneNumber = telephone  
            };

            var result = _sessionBL.Register(data);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            return RedirectToAction("Sing");
        }

        [HttpGet]
        public ActionResult Sing() => View();

        [HttpPost]
        public ActionResult Sing(string credential, string password)
        {
            var loginData = new ULoginData
            {
                Credential = credential,
                Password = password,
                LoginDateTime = DateTime.Now
            };

            var result = _sessionBL.Login(loginData);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            Session["UserId"] = result.UserId;
            Session["Username"] = result.Username;
            Session["Role"] = result.Role;

            return RedirectToAction("UserProfile");
        }

        [HttpGet]
        public ActionResult UserProfile()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Sing");

            int userId = (int)Session["UserId"];
            var user = _sessionBL.GetCurrentUser(userId);
            if (user == null)
                return RedirectToAction("Sing");

            return View(user); 
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Sing");

            int userId = (int)Session["UserId"];
            var user = _sessionBL.GetCurrentUser(userId);
            if (user == null)
                return RedirectToAction("Sing");

            var model = new UUserUpdate
            {
                Username = user.Username,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return View(model); 
        }

        [HttpPost]
        public ActionResult UpdateProfile(UUserUpdate model)
        {
            int userId = (int)Session["UserId"];
            var success = _sessionBL.UpdateUser(userId, model);

            TempData["Message"] = success ? "Профиль успешно обновлён." : "Ошибка: текущий пароль неверен.";

            return RedirectToAction("UserProfile");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Sing", "Auth"); 
        }
        public ActionResult AccessDenied() => View();
    }
}