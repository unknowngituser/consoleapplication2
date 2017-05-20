using MegaKids.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaKids.WebUI.Controllers
{
    public class ModulesController : DefaultController
    {
        #region Слайдер
        public ActionResult SliderPartial(EnumSitePage sitePage)
        {
            var model = MainServices.Modules.GetSliderList(CurrentLang.Id, sitePage);
            return PartialView(model);
        }
        #endregion
    }
}