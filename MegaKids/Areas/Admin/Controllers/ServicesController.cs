using MegaKids.IServices.Models.WebPage;
using MegaKids.WebUI.Controllers;
using MegaKids.WebUI.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaKids.WebUI.Areas.Admin.Controllers
{
    [FilterUser(Roles = "Администратор")]
    public class ServicesController : DefaultController
    {
        // GET: Admin/Services
        public ActionResult Index()
        {
            var seo = AdminServices.Modules.GetSeoSettings(DataModel.Models.EnumSitePage.Services);
            return View(seo);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(SeoLang seo)
        {
            AdminServices.Modules.UpdateSeoSettings(seo);
            return RedirectToAction("index", "services");
        }
        public ActionResult Management()
        {
            var services = AdminServices.Modules.GetServicesList();
            return View(services);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ServicesLang model)
        {
            string mapPath = Server.MapPath("~/Content/Images/services/");
            AdminServices.Modules.CreateServices(model, mapPath);
            return View();
        }
        /// <summary>
        /// Вывод информации для редактирования услуги
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var news = AdminServices.Modules.EditServices(id);
            return View(news);
        }
        /// <summary>
        /// Редактирование услуги
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult UpdateServices(ServicesLang model)
        {
            string map = Server.MapPath("~/Content/Images/services/");
            AdminServices.Modules.UpdateServices(model, map);
            return Json("Услуга успешно обновлена");
        }
        /// <summary>
        /// Удаление услуги
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteServices(int ServicesId)
        {
            AdminServices.Modules.DeleteServices(ServicesId);
            return Json("Успешно удалено");
        }
    }
}