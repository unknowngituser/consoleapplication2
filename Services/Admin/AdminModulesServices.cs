using MegaKids.DataModel;
using MegaKids.DataModel.Models;
using MegaKids.IServices.Models.WebPage;
using MegaKids.IServices.Subinterface.Admin;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaKids.IServices.Models;
using System.Web;
using System.IO;

namespace MegaKids.Services.Admin
{
    public class AdminModulesServices : IAdminModulesServices
    {
        #region Seo Settings
        /// <summary>
        /// Получение SEO настроек
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public SeoLang GetSeoSettings(EnumSitePage page)
        {
            using (var db = new DataContext())
            {
                var seoRu = db.SeoDescriptionLanguages.Include(x => x.SeoDescription)
                    .FirstOrDefault(x => x.LanguageId == EnumLanguage.ru && x.SeoDescriptionId == page);
                var seoRo = db.SeoDescriptionLanguages.Include(x => x.SeoDescription)
                    .FirstOrDefault(x => x.LanguageId == EnumLanguage.ro && x.SeoDescriptionId == page);
                var result = new SeoLang()
                {
                    Id = page,
                    Ru_Title = seoRu.Title,
                    Ru_Keywords = seoRu.Keywords,
                    Ru_Description = seoRu.Description,
                    Ru_PageContent = seoRu.PageContent,
                    Ru_ExtraContent = seoRu.ExtraContent,
                    Ro_Title = seoRo.Title,
                    Ro_Keywords = seoRo.Keywords,
                    Ro_Description = seoRo.Description,
                    Ro_PageContent = seoRo.PageContent,
                    Ro_ExtraContent = seoRo.ExtraContent
                };
                return result;
            }
        }
        /// <summary>
        /// Обновление SEO настроек
        /// </summary>
        /// <param name="seo"></param>
        public void UpdateSeoSettings(SeoLang seo)
        {
            using (var db = new DataContext())
            {
                var seoRu = db.SeoDescriptionLanguages
                    .FirstOrDefault(x => x.SeoDescriptionId == seo.Id && x.LanguageId == EnumLanguage.ru);
                var seoRo = db.SeoDescriptionLanguages
                    .FirstOrDefault(x => x.SeoDescriptionId == seo.Id && x.LanguageId == EnumLanguage.ro);
                seoRu.Title = seo.Ru_Title;
                seoRu.Keywords = seo.Ru_Keywords;
                seoRu.Description = seo.Ru_Description;
                seoRu.PageContent = seo.Ru_PageContent;
                seoRu.ExtraContent = seo.Ru_ExtraContent;
                seoRo.Title = seo.Ro_Title;
                seoRo.Keywords = seo.Ro_Keywords;
                seoRo.Description = seo.Ro_Description;
                seoRo.PageContent = seo.Ro_PageContent;
                seoRo.ExtraContent = seo.Ro_ExtraContent;
                db.SaveChanges();
            }
        }
        #endregion

        #region Услуги
        public List<ModelServices> GetServicesList()
        {
            using (var db = new DataContext())
            {
                var services = db.ServicesLanguages.Include(x => x.Services)
                    .Where(x => x.LanguageId == EnumLanguage.ru)
                    .OrderByDescending(x=>x.Services.CreateDate).ToList();
                var result = services.Select(x => ConvertToModelServices(x)).ToList();
                return result;
            }
        }

        /// <summary>
        /// Добавление услуги
        /// </summary>
        /// <param name="model"></param>
        public void CreateServices(ServicesLang model, string mapPath)
        {
            using (var db = new DataContext())
            {
                var services = new MegaKids.DataModel.Models.Services()
                {
                    CreateDate = (model.CreateDate != null) ? model.CreateDate : DateTime.Now
                };
                if (model.PhotoFile != null)
                {
                    services.Photo = model.PhotoFile.FileName;
                    UploadModuleImage(model.PhotoFile, mapPath);
                }
                db.Services.Add(services);
                var servicesLangRu = new ServicesLanguage()
                {
                    ServicesId = services.Id,
                    LanguageId = EnumLanguage.ru,
                    Title = model.Ru_Title,
                    Content = model.Ru_Content
                };
                db.ServicesLanguages.Add(servicesLangRu);
                var servicesLangRo = new ServicesLanguage()
                {
                    ServicesId = services.Id,
                    LanguageId = EnumLanguage.ro,
                    Title = model.Ro_Title,
                    Content = model.Ro_Content
                };
                db.ServicesLanguages.Add(servicesLangRo);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Получение данныхх услуги для редактирования
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServicesLang EditServices(int id)
        {
            using (var db = new DataContext())
            {
                var servicesRu = db.ServicesLanguages.Include(_ => _.Services)
                    .FirstOrDefault(_ => _.ServicesId == id && _.LanguageId == EnumLanguage.ru);
                var servicesRo = db.ServicesLanguages.Include(_ => _.Services)
                    .FirstOrDefault(_ => _.ServicesId == id && _.LanguageId == EnumLanguage.ro);
                var result = new ServicesLang()
                {
                    Id = servicesRu.ServicesId,
                    CreateDate = servicesRu.Services.CreateDate,
                    Photo = servicesRu.Services.Photo,
                    Ru_Title = servicesRu.Title,
                    Ru_Content = servicesRo.Content,
                    Ro_Title = servicesRo.Title,
                    Ro_Content = servicesRo.Content
                };
                return result;
            }
        }
        /// <summary>
        /// Редактирование услуги
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public void UpdateServices(ServicesLang model, string map)
        {
            using (var db = new DataContext())
            {
                var services = db.Services.FirstOrDefault(_ => _.Id == model.Id);
                var servicesRu = db.ServicesLanguages.Include(_ => _.Services)
                    .FirstOrDefault(_ => _.ServicesId == model.Id && _.LanguageId == EnumLanguage.ru);
                var servicesRo = db.ServicesLanguages.Include(_ => _.Services)
                    .FirstOrDefault(_ => _.ServicesId == model.Id && _.LanguageId == EnumLanguage.ro);
                if (model.PhotoFile != null)
                {
                    UploadModuleImage(model.PhotoFile, map);
                    services.Photo = model.PhotoFile.FileName;
                }
                services.CreateDate = model.CreateDate;

                servicesRu.Title = model.Ru_Title;
                servicesRu.Content = model.Ru_Content;
                servicesRo.Title = model.Ro_Title;
                servicesRo.Content = model.Ro_Content;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Удаление услуги
        /// </summary>
        /// <param name="id"></param>
        public void DeleteServices(int id)
        {
            using (var db = new DataContext())
            {
                var servicesLang = db.ServicesLanguages.Where(x => x.ServicesId == id);
                var services = db.Services.FirstOrDefault(x => x.Id == id);
                db.ServicesLanguages.RemoveRange(servicesLang);
                db.Services.Remove(services);
                db.SaveChanges();
            }
        }

        private void UploadModuleImage(HttpPostedFileBase photoFile, string mapPath)
        {
            if (!Directory.Exists(mapPath))
            {
                Directory.CreateDirectory(mapPath);
            }
            var fileName = Path.GetFileName(photoFile.FileName);
            var fullPath = Path.Combine(mapPath, fileName);
            photoFile.SaveAs(fullPath);
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
        public List<ModelSlider> GetSliderList(EnumSitePage sitePage)
        {
            using (var db = new DataContext())
            {
                var sliders = db.SliderLanguages.Include(x => x.Slider)
                    .Where(x => x.Slider.PageId == sitePage && x.LanguageId == EnumLanguage.ru).ToList();
                var result = sliders.Select(x => ConvertToModelSlider(x)).OrderByDescending(x=>x.CreateDate).ToList();
                return result;
            }
        }

        public void CreateSliderElement(SliderLang model, string mapPath)
        {
            using(var db = new DataContext())
            {
                var slider = new Slider()
                {
                    CreateDate = (model.CreateDate != null) ? model.CreateDate : DateTime.Now
                };
                if (model.PhotoFile != null)
                {
                    slider.Photo = model.PhotoFile.FileName;
                    UploadModuleImage(model.PhotoFile, mapPath);
                }
                db.Sliders.Add(slider);
                var sliderLangRu = new SliderLanguage()
                {
                    SliderId = slider.Id,
                    LanguageId = EnumLanguage.ru,
                    Title = model.Ru_Title,
                    Content = model.Ru_Content
                };
                db.SliderLanguages.Add(sliderLangRu);
                var sliderLangRo = new SliderLanguage()
                {
                    SliderId = slider.Id,
                    LanguageId = EnumLanguage.ro,
                    Title = model.Ro_Title,
                    Content = model.Ro_Content
                };
                db.SliderLanguages.Add(sliderLangRo);
                db.SaveChanges();
            }
        }

        public SliderLang EditSlider(int id)
        {
            using (var db = new DataContext())
            {
                var sliderRu = db.SliderLanguages.Include(_ => _.Slider)
                    .FirstOrDefault(_ => _.SliderId == id && _.LanguageId == EnumLanguage.ru);
                var sliderRo = db.SliderLanguages.Include(_ => _.Slider)
                    .FirstOrDefault(_ => _.SliderId == id && _.LanguageId == EnumLanguage.ro);
                var result = new SliderLang()
                {
                    Id = sliderRu.SliderId,
                    CreateDate = sliderRu.Slider.CreateDate,
                    Photo = sliderRu.Slider.Photo,
                    Ru_Title = sliderRu.Title,
                    Ru_Content = sliderRu.Content,
                    Ro_Title = sliderRo.Title,
                    Ro_Content = sliderRo.Content
                };
                return result;
            }
        }
        public void UpdateSlider(SliderLang model, string map)
        {
            using (var db = new DataContext())
            {
                var slider = db.Sliders.FirstOrDefault(_ => _.Id == model.Id);
                var sliderRu = db.SliderLanguages.Include(_ => _.Slider)
                    .FirstOrDefault(_ => _.SliderId == model.Id && _.LanguageId == EnumLanguage.ru);
                var sliderRo = db.SliderLanguages.Include(_ => _.Slider)
                    .FirstOrDefault(_ => _.SliderId == model.Id && _.LanguageId == EnumLanguage.ro);
                if (model.PhotoFile != null)
                {
                    UploadModuleImage(model.PhotoFile, map);
                    slider.Photo = model.PhotoFile.FileName;
                }
                slider.CreateDate = model.CreateDate;

                sliderRu.Title = model.Ru_Title;
                sliderRu.Content = model.Ru_Content;
                sliderRo.Title = model.Ro_Title;
                sliderRo.Content = model.Ro_Content;
                db.SaveChanges();
            }
        }
        public void DeleteSlider(int id)
        {
            using (var db = new DataContext())
            {
                var sliderLang = db.SliderLanguages.Where(x => x.SliderId == id);
                var slider = db.Sliders.FirstOrDefault(x => x.Id == id);
                db.SliderLanguages.RemoveRange(sliderLang);
                db.Sliders.Remove(slider);
                db.SaveChanges();
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
