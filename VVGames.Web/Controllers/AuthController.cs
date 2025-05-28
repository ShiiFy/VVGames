using System;
using System.Web.Mvc;
using VVGames.BusinessLogic;
using VVGames.BusinessLogic.Interface;
using VVGames.Domain.Entities.User;
using VVGames.Web.Filters;
using VVGames.Web.Models;

namespace VVGames.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly ISession _sessionBL;

        public AuthController()
        {
            var logic = new BusinesLogic();
            _sessionBL = logic.GetSessiionBL();
        }

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

        [Users]
        [HttpGet]
        public ActionResult UserProfile()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Sing");

            int userId = (int)Session["UserId"];
            var user = _sessionBL.GetCurrentUser(userId);
            if (user == null)
                return RedirectToAction("Sing");

            var model = new UserProfileViewModel
            {
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role,
                LoginDateTime = user.LoginDateTime
            };

            return View(model); 
        }

        [Users]
        [HttpGet]
        public ActionResult EditProfile()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("Sing");

            int userId = (int)Session["UserId"];
            var user = _sessionBL.GetCurrentUser(userId);
            if (user == null)
                return RedirectToAction("Sing");

            var viewModel = new EditProfileViewModel
            {
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return View(viewModel); 
        }

        [HttpPost]
        public ActionResult UpdateProfile(EditProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Ошибка валидации.";
                return View("EditProfile", model);
            }

            int userId = (int)Session["UserId"];

            var updateModel = new UUserUpdate
            {
                Name = model.Name,
                Username = model.Username,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                NewPassword = model.NewPassword,
                ConfirmPassword = model.ConfirmPassword,
                CurrentPassword = model.CurrentPassword
            };

            var success = _sessionBL.UpdateUser(userId, updateModel);

            if (!success)
            {
                TempData["Message"] = "Ошибка: текущий пароль неверен.";
                return View("EditProfile", model);
            }

            TempData["Message"] = "Профиль успешно обновлён.";
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