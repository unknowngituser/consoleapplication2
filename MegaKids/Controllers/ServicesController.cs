using MegaKids.DataModel.Models;
using MegaKids.IServices.Models.WebPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaKids.WebUI.Controllers
{
    public class ServicesController : DefaultController
    {
        // GET: Services
        public ActionResult Index()
        {
            var viewModel = new ViewModel()
            {
                Seo = MainServices.Modules.GetCurrentPageSeo(CurrentLang.Id, EnumSitePage.Services),
                ModelServices = MainServices.Modules.GetServicesList(CurrentLang)
            };
            return View(viewModel);
        }
    }
}