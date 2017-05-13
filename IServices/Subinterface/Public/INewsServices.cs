using MegaKids.DataModel.Models;
using MegaKids.IServices.Models;
using MegaKids.IServices.Models.Pagination;
using System.Collections.Generic;

namespace MegaKids.IServices.Subinterface.Public
{
    /// <summary>
    /// Определяет методы связанные с новостями
    /// </summary>
    public interface INewsServices
    {
        BaseTableViewModel<ModelNews> GetNewsList(TableFilterModel data, Language lang);
        List<ModelNews> GetNewsList(Language lang);

        ModelNews GetNews(int id, Language lang);

        List<ModelNews> GetRecentNews(int take, Language lang);
    }
}
