using MegaKids.DataModel.Models;
using MegaKids.IServices.Models;
using MegaKids.IServices.Models.WebPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.IServices.Subinterface.Admin
{
    public interface IAdminModulesServices
    {
        SeoLang GetSeoSettings(EnumSitePage page);
        void UpdateSeoSettings(SeoLang seo);

        List<ModelServices> GetServicesList();
        void CreateServices(ServicesLang model, string mapPath);
        ServicesLang EditServices(int id);
        void UpdateServices(ServicesLang model, string map);
        void DeleteServices(int id);

        List<ModelSlider> GetSliderList(EnumSitePage sitePage);
        void CreateSliderElement(SliderLang model, string mapPath);
        SliderLang EditSlider(int id);
        void UpdateSlider(SliderLang model, string map);
        void DeleteSlider(int id);
    }
}
