using MegaKids.DataModel;
using MegaKids.IServices;
using MegaKids.IServices.Models;
using MegaKids.IServices.Subinterface.Admin;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaKids.DataModel.Models;
using MegaKids.IServices.Models.WebPage;
using System.Web;
using System.IO;
using MegaKids.IServices.Models.Pagination;

namespace MegaKids.Services.Admin
{
    public class AdminAlbumServices : IAdminAlbumServices
    {
        public List<ModelAlbum> GetAlbumPhotos(int albumId)
        {
            using (var db = new DataContext())
            {
                var photos = db.Albums.Where(x => x.ParentId == albumId).ToList();
                var result = photos.Select(x => new ModelAlbum() { PhotoName = x.PhotoName }).ToList();
                return result;
            }
        }

        public List<ModelAlbum> GetAlbumList()
        {
            using (var db = new DataContext())
            {
                var albums = db.AlbumLanguages.Include(x => x.Album)
                    .Where(x => x.LanguageId == EnumLanguage.ru && x.Album.ParentId == null)
                    .OrderByDescending(x=>x.Album.CreateDate).ToList();
                var result = albums.Select(x => ConverToModelAlbum(x)).ToList();
                return result;
            }
        }

        public int CreateAlbum(AlbumLang model, string mapPath)
        {
            using (var db = new DataContext())
            {
                var album = new Album()
                {
                    CreateDate = (model.CreateDate == null) ? DateTime.Now : model.CreateDate
                };
                if (model.PhotoFile != null)
                {
                    album.PhotoName = model.PhotoFile.FileName;
                }
                db.Albums.Add(album);
                var albumRu = new AlbumLanguage()
                {
                    AlbumId = album.Id,
                    LanguageId = EnumLanguage.ru,
                    Name = model.Ru_Title
                };
                db.AlbumLanguages.Add(albumRu);
                var albumRo = new AlbumLanguage()
                {
                    AlbumId = album.Id,
                    LanguageId = EnumLanguage.ro,
                    Name = model.Ro_Title
                };
                db.AlbumLanguages.Add(albumRo);
                db.SaveChanges();
                if (model.PhotoFile != null)
                {
                    UploadAlbumImage(album.Id, model.PhotoFile, mapPath);
                }
                return album.Id;
            }
        }

        public AlbumLang EditAlbum(int id)
        {
            using (var db = new DataContext())
            {
                var albumRu = db.AlbumLanguages.Include(_ => _.Album)
                    .FirstOrDefault(_ => _.AlbumId == id && _.LanguageId == EnumLanguage.ru);
                var albumRo = db.AlbumLanguages.Include(_ => _.Album)
                    .FirstOrDefault(_ => _.AlbumId == id && _.LanguageId == EnumLanguage.ro);
                var result = new AlbumLang()
                {
                    Id = albumRu.AlbumId,
                    CreateDate = albumRu.Album.CreateDate,
                    PhotoName = albumRu.Album.PhotoName,
                    Ru_Title = albumRu.Name,
                    Ro_Title = albumRo.Name
                };
                return result;
            }
        }

        public void UpdateAlbum(AlbumLang model, string mapPath)
        {
            using (var db = new DataContext())
            {
                var album = db.Albums.FirstOrDefault(_ => _.Id == model.Id);
                var albumRu = db.AlbumLanguages.Include(_ => _.Album)
                    .FirstOrDefault(_ => _.AlbumId == model.Id && _.LanguageId == EnumLanguage.ru);
                var albumRo = db.AlbumLanguages.Include(_ => _.Album)
                    .FirstOrDefault(_ => _.AlbumId == model.Id && _.LanguageId == EnumLanguage.ro);
                if (model.PhotoFile != null)
                {
                    UploadAlbumImage(model.Id, model.PhotoFile, mapPath);
                    album.PhotoName = model.PhotoFile.FileName;
                }
                album.CreateDate = (model.CreateDate == null) ? DateTime.Now : model.CreateDate;

                albumRu.Name = model.Ru_Title;
                albumRo.Name = model.Ro_Title;
                db.SaveChanges();
            }
        }

        public void UploadAlbumPhotos(HttpFileCollectionBase files, int albumId, string mapPath)
        {
            string path = mapPath + albumId + "\\photos";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (var db = new DataContext())
            {
                foreach (string file in files)
                {
                    var upload = files[file];
                    var fileName = Path.GetFileName(upload.FileName);
                    var fullPath = Path.Combine(path, fileName);
                    db.Albums.Add(new Album()
                    {
                        CreateDate = DateTime.Now,
                        ParentId = albumId,
                        PhotoName = fileName
                    });
                    upload.SaveAs(fullPath);
                }
                db.SaveChanges();
            }            
        }

        public void DeleteAlbum(int id)
        {
            using (var db = new DataContext())
            {
                var albumLang = db.AlbumLanguages.Where(_ => _.AlbumId == id);
                db.AlbumLanguages.RemoveRange(albumLang);
                var albumChild = db.Albums.Where(_ => _.ParentId == id);
                db.Albums.RemoveRange(albumChild);
                var album = db.Albums.FirstOrDefault(x => x.Id == id);
                db.Albums.Remove(album);
                db.SaveChanges();
            }
        }

        public static ModelAlbum ConverToModelAlbum(AlbumLanguage album)
        {
            return new ModelAlbum()
            {
                Id = album.AlbumId,
                Name = album.Name,
                Descrition = album.Descrition,
                CreateDate = album.Album.CreateDate
                //PhotoName = album.Album.PhotoName
            };
        }

        public void UploadAlbumImage(int id, HttpPostedFileBase image, string mapPath)
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
        #region Видео
        public List<ModelGalleryVideo> GetGalleryVideos()
        {
            using (var db = new DataContext())
            {
                var videos = db.GalleryVideoLanguages.Include(x => x.GalleryVideo)
                    .Where(x => x.LanguageId == EnumLanguage.ru)
                    .OrderByDescending(x=>x.GalleryVideo.CreateDate).ToList();
                var result = videos.Select(x => ConvertToModelGalleryVideo(x)).ToList();
                return result;
            }
        }

        public void CreateVideoSlide(GalleryVideoLang model)
        {
            using (var db = new DataContext())
            {
                var video = new GalleryVideo()
                {
                    CreateDate = DateTime.Now
                };
                db.GalleryVideos.Add(video);
                var videoRu = new GalleryVideoLanguage()
                {
                    GalleryVideoId = video.Id,
                    LanguageId = EnumLanguage.ru,
                    Title = model.Ru_Title,
                    Video = model.Ru_Video
                };
                db.GalleryVideoLanguages.Add(videoRu);
                var videoRo = new GalleryVideoLanguage()
                {
                    GalleryVideoId = video.Id,
                    LanguageId = EnumLanguage.ro,
                    Title = model.Ro_Title,
                    Video = model.Ro_Video
                };
                db.GalleryVideoLanguages.Add(videoRo);
                db.SaveChanges();
            }
        }

        public GalleryVideoLang EditVideoSlide(int id)
        {
            using (var db = new DataContext())
            {
                var video = db.GalleryVideos.FirstOrDefault(x => x.Id == id);
                var videoRu = db.GalleryVideoLanguages
                    .FirstOrDefault(x => x.GalleryVideoId == id && x.LanguageId == EnumLanguage.ru);
                var videoRo = db.GalleryVideoLanguages
                    .FirstOrDefault(x => x.GalleryVideoId == id && x.LanguageId == EnumLanguage.ro);
                var result = new GalleryVideoLang()
                {
                    Id = video.Id,
                    Ru_Title = videoRu.Title,
                    Ru_Video = videoRu.Video,
                    Ro_Title = videoRo.Title,
                    Ro_Video = videoRo.Video
                };
                return result;
            }
        }

        public void UpdateVideoSlide(GalleryVideoLang model)
        {
            using (var db = new DataContext())
            {
                var videoRu = db.GalleryVideoLanguages
                    .FirstOrDefault(x => x.GalleryVideoId == model.Id && x.LanguageId == EnumLanguage.ru);
                videoRu.Title = model.Ru_Title;
                videoRu.Video = model.Ru_Video;
                var videoRo = db.GalleryVideoLanguages
                    .FirstOrDefault(x => x.GalleryVideoId == model.Id && x.LanguageId == EnumLanguage.ro);
                videoRo.Title = model.Ro_Title;
                videoRo.Video = model.Ro_Video;
                db.SaveChanges();
            }
        }

        public void DeleteVideoSlide(int id)
        {
            using (var db = new DataContext())
            {
                var video = db.GalleryVideos.FirstOrDefault(x => x.Id == id);
                db.GalleryVideos.Remove(video);
                var videoLang = db.GalleryVideoLanguages.Where(x => x.GalleryVideoId == id);
                db.GalleryVideoLanguages.RemoveRange(videoLang);
                db.SaveChanges();
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
        public List<ModelAlbum> GetCafeAlbumList()
        {
            using (var db = new DataContext())
            {
                var albums = db.CafeAlbumLanguages.Include(x => x.CafeAlbum)
                    .Where(x => x.LanguageId == EnumLanguage.ru && x.CafeAlbum.ParentId == null)
                    .OrderByDescending(x=>x.CafeAlbum.CreateDate).ToList();
                var result = albums.Select(x => ConvertCafeToModelAlbum(x)).ToList();
                return result;
            }
        }

        public int CreateCafeAlbum(AlbumLang model)
        {
            using (var db = new DataContext())
            {
                var album = new CafeAlbum()
                {
                    CreateDate = (model.CreateDate == null) ? DateTime.Now : model.CreateDate
                };
                db.CafeAlbums.Add(album);
                var albumRu = new CafeAlbumLanguage()
                {
                    CafeAlbumId = album.Id,
                    LanguageId = EnumLanguage.ru,
                    Name = model.Ru_Title
                };
                db.CafeAlbumLanguages.Add(albumRu);
                var albumRo = new CafeAlbumLanguage()
                {
                    CafeAlbumId = album.Id,
                    LanguageId = EnumLanguage.ro,
                    Name = model.Ro_Title
                };
                db.CafeAlbumLanguages.Add(albumRo);
                db.SaveChanges();
                return album.Id;
            }
        }
        public AlbumLang EditCafeAlbum(int id)
        {
            using (var db = new DataContext())
            {
                var albumRu = db.CafeAlbumLanguages.Include(_ => _.CafeAlbum)
                    .FirstOrDefault(_ => _.CafeAlbumId == id && _.LanguageId == EnumLanguage.ru);
                var albumRo = db.CafeAlbumLanguages.Include(_ => _.CafeAlbum)
                    .FirstOrDefault(_ => _.CafeAlbumId == id && _.LanguageId == EnumLanguage.ro);
                var result = new AlbumLang()
                {
                    Id = albumRu.CafeAlbumId,
                    Ru_Title = albumRu.Name,
                    Ro_Title = albumRo.Name
                };
                return result;
            }
        }
        public void UpdateCafeAlbum(AlbumLang model)
        {
            using (var db = new DataContext())
            {
                var albumRu = db.CafeAlbumLanguages.Include(_ => _.CafeAlbum)
                    .FirstOrDefault(_ => _.CafeAlbumId == model.Id && _.LanguageId == EnumLanguage.ru);
                var albumRo = db.CafeAlbumLanguages.Include(_ => _.CafeAlbum)
                    .FirstOrDefault(_ => _.CafeAlbumId == model.Id && _.LanguageId == EnumLanguage.ro);

                albumRu.Name = model.Ru_Title;
                albumRo.Name = model.Ro_Title;
                db.SaveChanges();
            }
        }

        public void DeleteSlider(int id, string mapPath)
        {
            using (var db = new DataContext())
            {
                try
                {
                    var sliderLang = db.CafeAlbumLanguages.Where(x => x.CafeAlbumId == id);
                    var slider = db.CafeAlbums.FirstOrDefault(x => x.Id == id);
                    var sliderPhotos = db.CafeAlbums.Where(x => x.ParentId == id);
                    db.CafeAlbumLanguages.RemoveRange(sliderLang);
                    db.CafeAlbums.Remove(slider);
                    db.CafeAlbums.RemoveRange(sliderPhotos);
                    db.SaveChanges();

                    string pathToFolder = mapPath;
                    DirectoryInfo diFolder = new DirectoryInfo(pathToFolder);
                    foreach (DirectoryInfo dir in diFolder.GetDirectories(id.ToString(), SearchOption.TopDirectoryOnly))
                    {
                        dir.Delete(true);
                    }
                }
                catch(Exception ex)
                {
                    return;
                }
                //string fullPath = mapPath + id + "\\photos";
                //DirectoryInfo diFiles = new DirectoryInfo(fullPath);
                //foreach (FileInfo file in diFiles.GetFiles())
                //{
                //    file.Delete();
                //}
            }
        }
        public void UploadCafeAlbumPhotos(HttpFileCollectionBase files, int albumId, string mapPath)
        {
            string path = mapPath + albumId + "\\photos";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (var db = new DataContext())
            {
                foreach (string file in files)
                {
                    var upload = files[file];
                    var fileName = Path.GetFileName(upload.FileName);
                    var fullPath = Path.Combine(path, fileName);
                    db.CafeAlbums.Add(new CafeAlbum()
                    {
                        CreateDate = DateTime.Now,
                        ParentId = albumId,
                        PhotoName = fileName
                    });
                    upload.SaveAs(fullPath);
                }
                db.SaveChanges();
            }
        }
        public static ModelAlbum ConvertCafeToModelAlbum(CafeAlbumLanguage album)
        {
            return new ModelAlbum()
            {
                Id = album.CafeAlbumId,
                Name = album.Name,
                //Descrition = album.Descrition,
                CreateDate = album.CafeAlbum.CreateDate
                //PhotoName = album.Album.PhotoName
            };
        }
        #endregion
    }
}
