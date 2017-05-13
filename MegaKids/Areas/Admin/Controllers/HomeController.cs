using MegaKids.WebUI.Controllers;
using MegaKids.WebUI.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaKids.WebUI.Areas.Admin.Controllers
{
    public class HomeController : DefaultController
    {
        /// <summary>
        /// Страница авторизации
        /// </summary>
        public ActionResult Index()
        {
            if (User.IsAuth)
            {
                return RedirectToAction("index", "dashboard");
            }
            else
            {
                return View();
            }
        }      
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <param name="RememberMe">Функция запомнить</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Index(string userName, string password, string RememberMe)
        {
            //WebUser.Register(userName, "", password);
            WebUser.Login(userName, password, RememberMe == "on");

            return RedirectToAction("index", "dashboard");
        }
        /// <summary>
        /// Выход из аккаунта
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult LogOut()
        {
            WebUser.LogOff();

            return RedirectToAction("index", "home");
        }
    }
}