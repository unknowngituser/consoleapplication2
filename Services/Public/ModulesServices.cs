using MegaKids.DataModel;
using MegaKids.DataModel.Models;
using MegaKids.IServices.Subinterface.Public;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaKids.IServices.Models.WebPage;
using MegaKids.IServices.Models;

namespace MegaKids.Services.Public
{
    public class ModulesServices:IModulesServices
    {
        public ModelSeoDescription GetCurrentPageSeo(EnumLanguage lang, EnumSitePage seo)
        {
            using (var db = new DataContext())
            {
                var currentSeo = db.SeoDescriptionLanguages
                    .FirstOrDefault(x => x.LanguageId == lang && x.SeoDescriptionId == seo);
                var result = new ModelSeoDescription()
                {
                    Id = currentSeo.SeoDescriptionId,
                    Title = currentSeo.Title,
                    Description = currentSeo.Description,
                    Keywords = currentSeo.Keywords,
                    PageContent = currentSeo.PageContent,
                    ExtraContent = currentSeo.ExtraContent
                };
                return result;
            }
        }
        #region Услуги
        public List<ModelServices> GetServicesList(Language lang)
        {
            using (var db = new DataContext())
            {
                var services = db.ServicesLanguages.Include(x => x.Services)
                    .Where(x => x.LanguageId == lang.Id)
                    .OrderByDescending(x=>x.Services.CreateDate).ToList();
                var result = services.Select(x => ConvertToModelServices(x)).ToList();
                return result;
            }
        }

        public static ModelServices ConvertToModelServices(ServicesLanguage model)
        {
            return new ModelServices()
            {
                Id = model.ServicesId,
                CreateDate = model.Services.CreateDate,
                Photo = model.Services.Photo,
                Title = model.Title,
                Content = model.Content
            };
        }
        #endregion

        #region Слайдер
        public List<ModelSlider> GetSliderList(EnumLanguage lang, EnumSitePage sitePage)
        {
            using (var db = new DataContext())
            {
                var sliders = db.SliderLanguages.Include(x => x.Slider)
                    .Where(x => x.Slider.PageId == sitePage && x.LanguageId == lang)
                    .OrderByDescending(x=>x.Slider.CreateDate).ToList();
                var result = sliders.Select(x => ConvertToModelSlider(x)).ToList();
                return result;
            }
        }

        public static ModelSlider ConvertToModelSlider(SliderLanguage model)
        {
            return new ModelSlider()
            {
                Id = model.SliderId,
                CreateDate = model.Slider.CreateDate,
                Photo = model.Slider.Photo,
                Title = model.Title,
                Content = model.Content
            };
        }
        #endregion
    }
}
