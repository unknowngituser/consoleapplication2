using MegaKids.DataModel.Models;
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
    public class ModulesController : DefaultController
    {
        // GET: Admin/Modules
        public ActionResult Index()
        {
            return View();
        }
        #region Сайдер
        public ActionResult SliderManagement(EnumSitePage sitePage)
        {
            var sliders = AdminServices.Modules.GetSliderList(sitePage);
            return View(sliders);
        }
        public ActionResult CreateSliderElement()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSliderElement(SliderLang model)
        {
            string mapPath = Server.MapPath("~/Content/Images/Slider/");
            AdminServices.Modules.CreateSliderElement(model, mapPath);
            return Json("Слайд успешно создан");
        }
        /// <summary>
        /// Вывод информации для редактирования слайдера
        /// </summary>
        /// <returns></returns>
        public ActionResult EditSlider(int id)
        {
            var news = AdminServices.Modules.EditSlider(id);
            return View(news);
        }
        /// <summary>
        /// Редактирование слайдера
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateSlider(SliderLang model)
        {
            string map = Server.MapPath("~/Content/Images/Slider/");
            AdminServices.Modules.UpdateSlider(model, map);
            return Json("Слайдер успешно обновлен");
        }
        /// <summary>
        /// Удаление элемента слайдера
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteSlider(int SliderId)
        {
            AdminServices.Modules.DeleteSlider(SliderId);
            return Json("Успешно удалено");
        }
        #endregion
    }
}