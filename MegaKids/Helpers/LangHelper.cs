using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MegaKids.WebUI.Helpers
{
    public static class LangHelper
    {
        public static MvcHtmlString LangSwitcher(this UrlHelper url, string Name, RouteData routeData, string lang)
        {
            //var liTagBuilder = new TagBuilder("li");
            var aTagBuilder = new TagBuilder("a");
            var routeValueDictionary = new RouteValueDictionary(routeData.Values);
            if (routeValueDictionary.ContainsKey("lang"))
            {
                aTagBuilder.AddCssClass("lang-btn navbar-brand");
                if (routeData.Values["lang"] as string == lang)
                {
                    //aTagBuilder.AddCssClass("lang-btn");
                }
                else
                {
                    routeValueDictionary["lang"] = lang;
                }
            }
            aTagBuilder.MergeAttribute("id", "lang-swither");
            aTagBuilder.MergeAttribute("href", url.RouteUrl(routeValueDictionary));
            aTagBuilder.SetInnerText(Name);
            //liTagBuilder.InnerHtml = aTagBuilder.ToString();
            return new MvcHtmlString(aTagBuilder.ToString());
        }
    }
}