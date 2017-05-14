using MegaKids.IServices.Subinterface.Public;
using MegaKids.DataModel;
using MegaKids.DataModel.Models;
using MegaKids.IServices.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaKids.IServices.Models.Pagination;

namespace MegaKids.Services.Public
{
    public class AlbumServices : IAlbumServices
    {
        public BaseTableViewModel<ModelAlbum> GetAlbumList(TableFilterModel data, Language lang)
        {
            var result = new BaseTableViewModel<ModelAlbum>();

            using (var db = new DataContext())
            {
                var query = db.AlbumLanguages.Include(x => x.Album)
                    .Where(x => x.LanguageId == lang.Id && x.Album.ParentId == null)
                    .OrderByDescending(x=>x.Album.CreateDate).ToList();

                var countRow = query.Count();
                result.CountPage = data.PageSize != 0 ? (int)(Math.Ceiling(countRow / (decimal)data.PageSize)) : 1;
                var currentPage = result.CountPage < data.CurrentPage - 1 ? result.CountPage : data.CurrentPage - 1;
                result.CountItems = countRow;
                result.List = query.Skip(data.PageSize * (currentPage)).Take(data.PageSize).ToList()
                    .Select(x=> new ModelAlbum()
                    {
                        Id = x.AlbumId,
                        Name = x.Name,
                        Descrition = x.Descrition,
                        CreateDate = x.Album.CreateDate,
                        PhotoName = x.Album.PhotoName
                    }).ToList();
                return result;
            }
        }

        
        public List<ModelAlbum> GetAlbumList(Language lang)
        {
            using (var db = new DataContext())
            {
                var albums = db.AlbumLanguages.Include(x => x.Album)
                    .Where(x => x.LanguageId == lang.Id && x.Album.ParentId == null).ToList();
                var result = albums.Select(x => ConverToModelAlbum(x)).ToList();
                return result;
            }
        }

        public List<ModelAlbum> GetAlbumPhotos(int albumId)
        {
            using (var db = new DataContext())
            {
                var photos = db.Albums.Where(x => x.ParentId == albumId).ToList();
                var result = photos.Select(x => ConverToModelAlbumAllPhoto(x)).ToList();
                return result;
            }
        }

        public ModelAlbum GetAlbumInfo(Language lang, int albumId)
        {
            using (var db = new DataContext())
            {
                var album = db.AlbumLanguages.Include(x => x.Album)
                    .FirstOrDefault(x => x.AlbumId == albumId && x.LanguageId == lang.Id);
                return ConverToModelAlbum(album);
            }
        }

        public List<ModelAlbum> GetRecentAlbums(Language lang, int? currentAlbum)
        {
            using (var db = new DataContext())
            {
                var albums = db.AlbumLanguages.Include(x => x.Album)
                    .Where(x => x.AlbumId != currentAlbum && x.LanguageId == lang.Id)
                    .OrderByDescending(x=>x.Album.CreateDate).Take(3).ToList();
                var result = albums.Select(x => ConverToModelAlbum(x)).ToList();
                return result;
            }
        }

        public static ModelAlbum ConverToModelAlbumAllPhoto(Album album)
        {
            return new ModelAlbum()
            {
                Id = album.Id,
                CreateDate = album.CreateDate,
                PhotoName = album.PhotoName
            };
        }
        public static ModelAlbum ConverToModelAlbum(AlbumLanguage album)
        {
            return new ModelAlbum()
            {
                Id = album.AlbumId,
                Name = album.Name,
                Descrition = album.Descrition,
                CreateDate = album.Album.CreateDate,
                PhotoName = album.Album.PhotoName
            };
        }

        #region Видео
        public List<ModelGalleryVideo> GetGalleryVideoList(Language lang)
        {

            using (var db = new DataContext())
            {
                var videos = db.GalleryVideoLanguages.Include(x => x.GalleryVideo)
                    .Where(x => x.LanguageId == lang.Id)
                    .OrderByDescending(x => x.GalleryVideo.CreateDate).ToList();
                var result = videos.Select(x => ConvertToModelGalleryVideo(x)).ToList();
                return result;
                //var query = db.AlbumLanguages.Include(x => x.Album)
                //    .Where(x => x.LanguageId == lang.Id && x.Album.ParentId == null)
                //    .OrderByDescending(x => x.Album.CreateDate).ToList();

                //var countRow = query.Count();
                //result.CountPage = data.PageSize != 0 ? (int)(Math.Ceiling(countRow / (decimal)data.PageSize)) : 1;
                //var currentPage = result.CountPage < data.CurrentPage - 1 ? result.CountPage : data.CurrentPage - 1;
                //result.CountItems = countRow;
                //result.List = query.Skip(data.PageSize * (currentPage)).Take(data.PageSize).ToList()
                //    .Select(x => new ModelAlbum()
                //    {
                //        Id = x.AlbumId,
                //        Name = x.Name,
                //        Descrition = x.Descrition,
                //        CreateDate = x.Album.CreateDate,
                //        PhotoName = x.Album.PhotoName
                //    }).ToList();
                //return result;
            }
        }
        public List<ModelGalleryVideo> GetGalleryVideos(Language lang)
        {
            using (var db = new DataContext())
            {
                var videos = db.GalleryVideoLanguages.Include(x => x.GalleryVideo)
                    .Where(x => x.LanguageId == lang.Id)
                    .OrderByDescending(x=>x.GalleryVideo.CreateDate).ToList();
                var result = videos.Select(x => ConvertToModelGalleryVideo(x)).ToList();
                return result;
            }
        }

        public static ModelGalleryVideo ConvertToModelGalleryVideo(GalleryVideoLanguage model)
        {
            return new ModelGalleryVideo()
            {
                Id = model.GalleryVideoId,
                CreateDate = model.GalleryVideo.CreateDate,
                Title = model.Title,
                Video = model.Video
            };
        }
        #endregion

        #region Кафе
        public List<ModelCafeAlbum> GetCafeAlbumList(Language lang)
        {
            using (var db = new DataContext())
            {
                var albums = db.CafeAlbumLanguages.Include(x => x.CafeAlbum)
                    .Where(x => x.LanguageId == lang.Id && x.CafeAlbum.ParentId == null)
                    .OrderByDescending(x=>x.CafeAlbum.CreateDate).ToList();
                var result = albums.Select(x => ConvertToModelCafeAlbum(x)).ToList();
                foreach(var album in result)
                {
                    var childPhotos = db.CafeAlbums.Where(x => x.ParentId == album.Id).ToList();
                    album.ChildPhotos = childPhotos.Select(x => ConvertCafePhotos(x)).ToList();
                }
                return result;
            }
        }
        public static ModelCafeAlbum ConvertToModelCafeAlbum(CafeAlbumLanguage album)
        {
            return new ModelCafeAlbum()
            {
                Id = album.CafeAlbumId,
                Name = album.Name,
                //Descrition = album.Descrition,
                CreateDate = album.CafeAlbum.CreateDate
                //PhotoName = album.Album.PhotoName
            };
        }
        public static ModelCafeAlbum ConvertCafePhotos(CafeAlbum album)
        {
            return new ModelCafeAlbum()
            {
                Id = album.Id,
                CreateDate = album.CreateDate,
                PhotoName = album.PhotoName
            };
        }
        #endregion
    }
}
