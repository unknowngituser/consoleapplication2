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
    public class AboutController : DefaultController
    {
        // GET: Admin/About
        public ActionResult Index()
        {
            var seo = AdminServices.Modules.GetSeoSettings(DataModel.Models.EnumSitePage.About);
            return View(seo);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(SeoLang seo)
        {
            AdminServices.Modules.UpdateSeoSettings(seo);
            return RedirectToAction("index", "about");
        }
    }
}