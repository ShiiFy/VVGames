using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VVGames.BusinessLogic.BL;

namespace VVGames.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminBL _adminBL = new AdminBL();

        [HttpGet]
        public ActionResult Dashboard()
        {
            if (Session["Role"]?.ToString() != "Admin" && Session["Role"]?.ToString() != "SuperAdmin")
                return RedirectToAction("AccessDenied", "Auth");

            return View(); 
        }

        [HttpGet]
        public ActionResult UserManagement()
        {
            if (Session["Role"]?.ToString() != "Admin" && Session["Role"]?.ToString() != "SuperAdmin")
                return RedirectToAction("AccessDenied", "Auth");

            var users = _adminBL.GetAllUsers(); 
            return View(users); 
        }

        [HttpPost]
        public ActionResult ToggleBlock(int userId)
        {
            var success = _adminBL.ToggleUserBlock(userId);
            if (!success)
            {
                TempData["Message"] = "Ошибка при блокировке.";
            }

            return RedirectToAction("UserManagement");
        }

        [HttpPost]
        public ActionResult ToggleAdmin(int userId)
        {
            var success = _adminBL.ToggleUserRole(userId);

            if (!success)
            {
                TempData["Message"] = "Ошибка при изменении роли.";
            }

            return RedirectToAction("UserManagement");
        }
    }
}