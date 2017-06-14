using MegaKids.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaKids.WebUI.Controllers
{
    public class AboutController : DefaultController
    {
        // GET: About
        public ActionResult Index()
        {
            var seo = MainServices.Modules.GetCurrentPageSeo(CurrentLang.Id, EnumSitePage.About);
            return View(seo);
        }

        public ActionResult _mapContacts()
        {
            var contacts = MainServices.Modules.GetContacts(CurrentLang.Id);
            return PartialView(contacts);
        }
    }
}