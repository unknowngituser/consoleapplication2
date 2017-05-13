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
    public class NewsController : DefaultController
    {
        // GET: Admin/News
        public ActionResult Index()
        {
            var seo = AdminServices.Modules.GetSeoSettings(DataModel.Models.EnumSitePage.News);
            return View(seo);
        }
        [HttpPost]
        public ActionResult Index(SeoLang seo)
        {
            AdminServices.Modules.UpdateSeoSettings(seo);
            return RedirectToAction("index", "news");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(NewsLang model)
        {
            string mapPath = Server.MapPath("~/Content/Images/NewsImages/");
            AdminServices.News.CreateNews(model, mapPath);
            return View();
        }

        /// <summary>
        /// Создает перемнную в которой находится путь для сохранения файла и далее выполняет метод сохраняющий изображения 
        /// </summary>
        /// <param name="Upload">Файл</param>
        /// <param name="CKEditorFuncNum">Идентификационный номер анонимной функции обратного вызова после загрузки</param>
        /// <returns></returns>
        public ActionResult UploadImage(HttpPostedFileBase Upload, string CKEditorFuncNum, NewsLang model)
        {
            var host = HttpContext.Request.Url.Authority;
            string map = Server.MapPath("~/Content/Images/NewsImages/");
            string output = AdminServices.News.ProcessRequest(Upload, CKEditorFuncNum, map, host);
            return Content(output);
        }
        /// <summary>
        /// Управление новостями
        /// </summary>
        /// <returns></returns>
        public ActionResult Management()
        {
            var news = AdminServices.News.GetAllNews();
            return View(news);
        }
        /// <summary>
        /// Вывод информации для редактирования новости
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var news = AdminServices.News.EditNews(id);
            return View(news);
        }
        /// <summary>
        /// Редактирование новости
        /// </summary>
        /// <returns></returns>
        [ValidateInput(false)]
        public ActionResult UpdateNews(NewsLang model)
        {
            string map = Server.MapPath("~/Content/Images/NewsImages/");
            AdminServices.News.UpdateNews(model, map);
            return Json("Новость успешно обновлена");
        }
        /// <summary>
        /// Удаление новости
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteNews(int NewsId)
        {
            AdminServices.News.DeleteNews(NewsId);
            return Json("Успешно удалено");
        }
    }
}