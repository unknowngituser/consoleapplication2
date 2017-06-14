using MegaKids.DataModel.Models;
using MegaKids.IServices.Models;
using MegaKids.IServices.Models.WebPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.IServices.Subinterface.Public
{
    public interface IModulesServices
    {
        ModelSeoDescription GetCurrentPageSeo(EnumLanguage lang, EnumSitePage seo);

        List<ModelServices> GetServicesList(Language lang);

        List<ModelSlider> GetSliderList(EnumLanguage lang, EnumSitePage sitePage);

        /// <summary>
        /// Получить контакты
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        ModelSeoDescription GetContacts(EnumLanguage lang);
    }
}
