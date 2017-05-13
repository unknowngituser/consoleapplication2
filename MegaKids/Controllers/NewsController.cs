using MegaKids.DataModel.Models;
using MegaKids.IServices.Models.Pagination;
using MegaKids.IServices.Models.WebPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaKids.WebUI.Controllers
{
    public class NewsController : DefaultController
    {
        // GET: News
        public ActionResult Index()
        {
            var model = MainServices.Modules.GetCurrentPageSeo(CurrentLang.Id, EnumSitePage.News);

            return View(model);
        }

        public ActionResult WatchNews(int id)
        {
            var model = MainServices.News.GetNews(id, CurrentLang);
            return View(model);
        }

        public JsonResult GetNewsList(TableFilterModel data)
        {
            try
            {
                var listPage = MainServices.News.GetNewsList(data, CurrentLang);
                return Json(listPage);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }
    }
}