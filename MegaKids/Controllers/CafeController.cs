using MegaKids.IServices.Models.WebPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaKids.WebUI.Controllers
{
    public class CafeController : DefaultController
    {
        // GET: Cafe
        public ActionResult Index()
        {
            var viewModel = new ViewModel()
            {
                Seo = MainServices.Modules.GetCurrentPageSeo(CurrentLang.Id, DataModel.Models.EnumSitePage.Cafe),
                ModelCafeAlbum = MainServices.Albums.GetCafeAlbumList(CurrentLang)
            };
            return View(viewModel);
        }
    }
}