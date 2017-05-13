using MegaKids.DataModel.Models;
using MegaKids.IServices.Models;
using MegaKids.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaKids.WebUI.Infrastructura
{
    public class CustomWebViewPage : System.Web.Mvc.WebViewPage
    {
        public CustomWebViewPage()
        {
            User = WebUser.CurrentUser;
            Lang = DefaultController.CurrentLang;
        }

        public new ModelUser User { get; set; }

        public Language Lang { get; set; }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class CustomWebViewPage<T> : System.Web.Mvc.WebViewPage<T>
    {
        public CustomWebViewPage()
        {
            User = WebUser.CurrentUser;
            Lang = DefaultController.CurrentLang;
        }
        public new ModelUser User { get; set; }

        public Language Lang { get; set; }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}