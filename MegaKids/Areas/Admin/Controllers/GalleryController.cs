using MegaKids.IServices.Models.WebPage;
using MegaKids.WebUI.Controllers;
using MegaKids.WebUI.Infrastructura;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaKids.WebUI.Areas.Admin.Controllers
{
    [FilterUser(Roles = "Администратор")]
    public class GalleryController : DefaultController
    {
        // GET: Admin/Gallery
        public ActionResult Index()
        {
            var seo = AdminServices.Modules.GetSeoSettings(DataModel.Models.EnumSitePage.Gallery);
            return View(seo);
        }
        [HttpPost]
        public ActionResult Index(SeoLang seo)
        {
            AdminServices.Modules.UpdateSeoSettings(seo);
            return RedirectToAction("index", "gallery");
        }
        public ActionResult Management()
        {
            var albums = AdminServices.Albums.GetAlbumList();
            return View(albums);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AlbumLang model)
        {
            string mapPath = Server.MapPath("~/Content/Images/gallery/albums/");
            var albumId = AdminServices.Albums.CreateAlbum(model, mapPath);
            return View();
        }
        public ActionResult Edit(int id)
        {
            var model = AdminServices.Albums.EditAlbum(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateAlbum(AlbumLang model)
        {
            string mapPath = Server.MapPath("~/Content/Images/gallery/albums/");
            AdminServices.Albums.UpdateAlbum(model, mapPath);
            return Json("Альбом успешно изменен");
        }
        [HttpPost]
        public JsonResult UploadAlbumPhotos(int AlbumId)
        {
            string mapPath = Server.MapPath("~/Content/Images/gallery/albums/");
            var files = Request.Files;
            AdminServices.Albums.UploadAlbumPhotos(files, AlbumId, mapPath);
            return Json("Загрузка завершена");
        }
        [HttpPost]
        public ActionResult DeleteAlbum(int AlbumId)
        {
            AdminServices.Albums.DeleteAlbum(AlbumId);
            return Json("Успешно удалено");
        }
        public ActionResult Videos()
        {
            var videos = AdminServices.Albums.GetGalleryVideos();
            return View(videos);
        }
        public ActionResult CreateVideoSlide()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateVideoSlide(GalleryVideoLang model)
        {
            AdminServices.Albums.CreateVideoSlide(model);
            return RedirectToAction("videos","gallery");
        }
        public ActionResult EditVideoSlide(int id)
        {
            var model = AdminServices.Albums.EditVideoSlide(id);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditVideoSlide(GalleryVideoLang model)
        {
            AdminServices.Albums.UpdateVideoSlide(model);
            return RedirectToAction("videos", "gallery");
        }
        [HttpPost]
        public ActionResult DeleteVideoSlide(int VideoId)
        {
            AdminServices.Albums.DeleteVideoSlide(VideoId);
            return Json("Успешно удалено");
        }

        public ActionResult GetAlbumPhotosJson(int AlbumId)
        {
            try
            {
                var photoList = AdminServices.Albums.GetAlbumPhotos(AlbumId);
                return Json(photoList);
            }
            catch(Exception ex)
            {
                return Json(new { Result = "Error", ex.Message });
            }
        }

        public ActionResult DeletePhotoJson(int PhotoId)
        {
            string mapPath = Server.MapPath("~/Content/Images/gallery/albums/");
            try
            {
                AdminServices.Albums.DeleteAlbumPhoto(PhotoId,mapPath);
                return Json("Успешно удалено");
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", ex.Message });
            }
        }
    }
}