using MegaKids.DataModel;
using MegaKids.DataModel.Models;
using MegaKids.IServices.Models;
using MegaKids.IServices.Subinterface.Public;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MegaKids.IServices.Models.Pagination;

namespace MegaKids.Services.Public
{
    public class NewsServices : INewsServices
    {
        public BaseTableViewModel<ModelNews> GetNewsList(TableFilterModel data, Language lang)
        {
            var result = new BaseTableViewModel<ModelNews>();

            using (var db = new DataContext())
            {
                var query = db.NewsLanguages.Include(x => x.News)
                    .Where(x => x.LanguageId == lang.Id).OrderByDescending(x=>x.News.CreateDate).ToList();

                var countRow = query.Count();
                result.CountPage = data.PageSize != 0 ? (int)(Math.Ceiling(countRow / (decimal)data.PageSize)) : 1;
                var currentPage = result.CountPage < data.CurrentPage - 1 ? result.CountPage : data.CurrentPage - 1;
                result.CountItems = countRow;
                result.List = query.Skip(data.PageSize * (currentPage)).Take(data.PageSize).ToList()
                    .Select(x => ConverToModelNews(x)).ToList();
                return result;
            }
        }

        public List<ModelNews> GetNewsList(Language lang)
        {
            using(var db=new DataContext())
            {
                var news = db.NewsLanguages.Include(x => x.News).Where(x => x.LanguageId == lang.Id).ToList();
                var result = news.Select(x => ConverToModelNews(x)).ToList();
                return result;
            }
        }

        public ModelNews GetNews(int id, Language lang)
        {
            using (var db = new DataContext())
            {
                var news = db.NewsLanguages.Include(x => x.News)
                    .FirstOrDefault(x => x.NewsId == id && x.LanguageId == lang.Id);
                var result = ConverToModelNews(news);
                return result;
            }
        }
        /// <summary>
        /// Получение последних новостей
        /// </summary>
        /// <param name="take"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public List<ModelNews> GetRecentNews(int take, Language lang)
        {
            using(var db = new DataContext())
            {
                var recentNews = db.NewsLanguages.Include(x => x.News).OrderByDescending(x=>x.News.CreateDate)
                    .Where(x=>x.LanguageId==lang.Id).Take(take).ToList();
                var result = recentNews.Select(x => ConverToModelNews(x)).ToList();
                return result;
            }
        }

        public static ModelNews ConverToModelNews(NewsLanguage news)
        {
            return new ModelNews()
            {
                Id = news.News.Id,
                CreateDate = news.News.CreateDate,
                Photo = news.News.Photo,
                Title = news.Title,
                Seo_Keywords = news.Seo_Keywords,
                Seo_Description = news.Seo_Description,
                NewsContent = news.NewsContent,
                PreviewContent = news.PreviewContent
            };
        }

        
        
    }
}
