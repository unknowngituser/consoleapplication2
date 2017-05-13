using MegaKids.DataModel.Models;
using MegaKids.IServices.Models;
using MegaKids.IServices.Models.WebPage;
using System.Collections.Generic;
using System.Web;

namespace MegaKids.IServices.Subinterface.Admin
{
    /// <summary>
    /// Определяет методы связанные с новостями
    /// </summary>
    public interface IAdminNewsServices
    {
        List<ModelNews> GetAllNews();
        void CreateNews(NewsLang model, string mapPath);
        NewsLang EditNews(int id);
        void UpdateNews(NewsLang model, string map);
        void DeleteNews(int id);
        string ProcessRequest(HttpPostedFileBase upload, string CKEditorFuncNum, string mapPath, string host);

        
    }
}
