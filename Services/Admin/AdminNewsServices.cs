using MegaKids.DataModel;
using MegaKids.IServices.Subinterface.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using MegaKids.IServices.Models.WebPage;
using MegaKids.DataModel.Models;
using MegaKids.IServices.Models;
using MegaKids.Services.Public;

namespace MegaKids.Services.Admin
{
    public class AdminNewsServices : IAdminNewsServices
    {
        public List<ModelNews> GetAllNews()
        {
            using(var db = new DataContext())
            {
                var news = db.NewsLanguages.Include(_ => _.News)
                    .Where(_ => _.LanguageId == EnumLanguage.ru).ToList();
                var result = news.Select(x => ConverToModelNews(x)).OrderByDescending(x=>x.CreateDate).ToList();
                return result;
            }
        }
        /// <summary>
        /// Добавление новости
        /// </summary>
        /// <param name="model"></param>
        public void CreateNews(NewsLang model, string mapPath)
        {
            using(var db = new DataContext())
            {
                var news = new News()
                {
                    CreateDate = model.CreateDate == null ? DateTime.Now : model.CreateDate,
                    Photo = (model.PhotoFile != null) ? model.PhotoFile.FileName : null
                };
                db.News.Add(news);
                var newsLangRu = new NewsLanguage()
                {
                    NewsId = news.Id,
                    LanguageId = EnumLanguage.ru,
                    Title = model.Ru_Title,
                    Seo_Keywords = model.Ru_Seo_Keywords,
                    Seo_Description = model.Ru_Seo_Description,
                    NewsContent = model.Ru_NewsContent,
                    PreviewContent = model.Ru_PreviewContent
                };
                db.NewsLanguages.Add(newsLangRu);
                var newsLangRo = new NewsLanguage()
                {
                    NewsId = news.Id,
                    LanguageId = EnumLanguage.ro,
                    Title = model.Ro_Title,
                    Seo_Keywords = model.Ro_Seo_Keywords,
                    Seo_Description = model.Ro_Seo_Description,
                    NewsContent = model.Ro_NewsContent,
                    PreviewContent = model.Ro_PreviewContent
                };
                db.NewsLanguages.Add(newsLangRo);
                db.SaveChanges();
                if (model.PhotoFile != null) { UploadNewsImage(news.Id, model.PhotoFile, mapPath); }
            }
        }
        /// <summary>
        /// Получение данныхх новости для редактирования
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsLang EditNews(int id)
        {
            using(var db = new DataContext())
            {
                var newsRu = db.NewsLanguages.Include(_ => _.News)
                    .FirstOrDefault(_ => _.NewsId == id && _.LanguageId == EnumLanguage.ru);
                var newsRo = db.NewsLanguages.Include(_ => _.News)
                    .FirstOrDefault(_ => _.NewsId == id && _.LanguageId == EnumLanguage.ro);
                var result = new NewsLang()
                {
                    Id = newsRu.NewsId,
                    Photo = newsRu.News.Photo,
                    CreateDate = newsRu.News.CreateDate,
                    Ru_Title = newsRu.Title,
                    Ru_Seo_Keywords = newsRu.Seo_Keywords,
                    Ru_Seo_Description = newsRu.Seo_Description,
                    Ru_NewsContent = newsRu.NewsContent,
                    Ru_PreviewContent = newsRu.PreviewContent,
                    Ro_Title = newsRo.Title,
                    Ro_Seo_Keywords = newsRo.Seo_Keywords,
                    Ro_Seo_Description = newsRo.Seo_Description,
                    Ro_NewsContent = newsRo.NewsContent,
                    Ro_PreviewContent = newsRo.PreviewContent
                };
                return result;
            }
        }
        /// <summary>
        /// Редактирование новости
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public void UpdateNews(NewsLang model, string map)
        {
            using (var db = new DataContext())
            {
                var news = db.News.FirstOrDefault(_ => _.Id == model.Id);
                var newsRu = db.NewsLanguages.Include(_ => _.News)
                    .FirstOrDefault(_ => _.NewsId == model.Id && _.LanguageId == EnumLanguage.ru);
                var newsRo = db.NewsLanguages.Include(_ => _.News)
                    .FirstOrDefault(_ => _.NewsId == model.Id && _.LanguageId == EnumLanguage.ro);
                if (model.PhotoFile != null)
                {
                    UploadNewsImage(model.Id, model.PhotoFile, map);
                    news.Photo = model.PhotoFile.FileName;
                }
                news.CreateDate = model.CreateDate;
                
                newsRu.Title = model.Ru_Title;
                newsRu.Seo_Keywords = model.Ru_Seo_Keywords;
                newsRu.Seo_Description = model.Ru_Seo_Description;
                newsRu.NewsContent = model.Ru_NewsContent;
                newsRu.PreviewContent = model.Ru_PreviewContent;
                newsRo.Title = model.Ro_Title;
                newsRo.Seo_Keywords = model.Ro_Seo_Keywords;
                newsRo.Seo_Description = model.Ro_Seo_Description;
                newsRo.NewsContent = model.Ro_NewsContent;
                newsRo.PreviewContent = model.Ro_PreviewContent;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Удаление новости
        /// </summary>
        /// <param name="id"></param>
        public void DeleteNews(int id)
        {
            using(var db = new DataContext())
            {
                var newsLang = db.NewsLanguages.Where(x => x.NewsId == id);
                var news = db.News.FirstOrDefault(x => x.Id == id);
                db.NewsLanguages.RemoveRange(newsLang);
                db.News.Remove(news);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Загржает изображение на сервер и получает путь к файлу изображения
        /// </summary>
        /// <param name="upload">Изображения</param>
        /// <param name="CKEditorFuncNum">Идентификационный номер анонимного функции обратного вызова после загрузки</param>
        /// <param name="mapPath">Путь для сохранения файла</param>
        /// <returns>Возвращает строку с Ajax запросом</returns>
        public string ProcessRequest(HttpPostedFileBase upload, string CKEditorFuncNum, string mapPath, string host)
        {
            if (upload.ContentLength <= 0)
                return null;
            using (var db = new DataContext())
            {
                const string folder = "UploadImages";
                const string uploadFolder = "/Content/Images/NewsImages/";
                // сохраняем файл в папку img в проекте
                if(!Directory.Exists(mapPath + folder))
                {
                    Directory.CreateDirectory(mapPath + folder);
                }
                var fileName = Path.GetFileName(upload.FileName);
                var path = Path.Combine(mapPath + "/" + folder, fileName);
                upload.SaveAs(path);
                var url = string.Format("{0}{1}/{2}/{3}/{4}", "http://", host, uploadFolder, folder, fileName);
                const string message = "Ваше изображение успешно загружено";
                // Ajax запрос для передачи изображение
                var output = string.Format(
                    "<html><body><script>window.parent.CKEDITOR.tools.callFunction({0}, \"{1}\", \"{2}\");</script></body></html>",
                    CKEditorFuncNum, url, message);
                return output;
            }
        }
        public void UploadNewsImage(int id, HttpPostedFileBase image, string mapPath)
        {
            string path = mapPath + id;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var fileName = Path.GetFileName(image.FileName);
            var fullPath = Path.Combine(path, fileName);
            image.SaveAs(fullPath);
        }
        

        public static ModelNews ConverToModelNews(NewsLanguage news)
        {
            return new ModelNews()
            {
                Id = news.News.Id,
                CreateDate = news.News.CreateDate,
                Title = news.Title
            };
        }

    }
}
