using MegaKids.DataModel.Models;
using MegaKids.IServices.Models;
using MegaKids.IServices.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaKids.IServices.Subinterface.Public
{
    public interface IAlbumServices
    {
        BaseTableViewModel<ModelAlbum> GetAlbumList(TableFilterModel data, Language lang);
        List<ModelAlbum> GetAlbumList(Language lang);

        List<ModelAlbum> GetAlbumPhotos(int albumId);

        ModelAlbum GetAlbumInfo(Language lang, int albumId);

        List<ModelAlbum> GetRecentAlbums(Language lang, int? currentAlbum);

        #region Видео
        List<ModelGalleryVideo> GetGalleryVideoList(Language lang);

        List<ModelGalleryVideo> GetGalleryVideos(Language lang);
        #endregion

        #region Кафе
        List<ModelCafeAlbum> GetCafeAlbumList(Language lang);
        #endregion
    }
}
