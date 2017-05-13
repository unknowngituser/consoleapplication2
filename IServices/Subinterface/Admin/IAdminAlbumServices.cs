using MegaKids.IServices.Models;
using MegaKids.IServices.Models.Pagination;
using MegaKids.IServices.Models.WebPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MegaKids.IServices.Subinterface.Admin
{
    public interface IAdminAlbumServices
    {
        List<ModelAlbum> GetAlbumPhotos(int albumId);

        List<ModelAlbum> GetAlbumList();

        int CreateAlbum(AlbumLang model, string mapPath);

        AlbumLang EditAlbum(int id);

        void UpdateAlbum(AlbumLang model, string mapPath);

        void UploadAlbumPhotos(HttpFileCollectionBase files, int albumId, string mapPath);

        void DeleteAlbum(int id);
        #region Видео
        List<ModelGalleryVideo> GetGalleryVideos();
        void CreateVideoSlide(GalleryVideoLang model);
        GalleryVideoLang EditVideoSlide(int id);
        void UpdateVideoSlide(GalleryVideoLang model);
        void DeleteVideoSlide(int id);
        #endregion
        #region Кафе
        List<ModelAlbum> GetCafeAlbumList();
        int CreateCafeAlbum(AlbumLang model);
        AlbumLang EditCafeAlbum(int id);
        void UpdateCafeAlbum(AlbumLang model);
        void UploadCafeAlbumPhotos(HttpFileCollectionBase files, int albumId, string mapPath);
        void DeleteSlider(int id, string mapPath);
        #endregion
    }
}
