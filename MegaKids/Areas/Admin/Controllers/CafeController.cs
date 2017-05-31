using MegaKids.IServices.Models.WebPage;
using MegaKids.WebUI.Controllers;
using MegaKids.WebUI.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MegaKids.WebUI.Areas.Admin.Controllers
{
    [FilterUser(Roles = "Администратор")]
    public class CafeController : DefaultController
    {
        // GET: Admin/Cafe
        public ActionResult Index()
        {
            var seo = AdminServices.Modules.GetSeoSettings(DataModel.Models.EnumSitePage.Cafe);
            return View(seo);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(SeoLang seo)
        {
            AdminServices.Modules.UpdateSeoSettings(seo);
            return RedirectToAction("index", "cafe");
        }

        public ActionResult Management()
        {
            var albums = AdminServices.Albums.GetCafeAlbumList();
            return View(albums);
        }
        public ActionResult CreateSlider()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSlider(AlbumLang model)
        {
            var sliderId = AdminServices.Albums.CreateCafeAlbum(model);
            return RedirectToAction("EditSlider","cafe",new { id = sliderId });
        }
        public ActionResult EditSlider(int id)
        {
            var model = AdminServices.Albums.EditCafeAlbum(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateSlider(AlbumLang model)
        {
            AdminServices.Albums.UpdateCafeAlbum(model);
            return Json("Альбом успешно изменен");
        }
        [HttpPost]
        public JsonResult UploadSliderPhotos(int AlbumId)
        {
            string mapPath = Server.MapPath("~/Content/Images/cafe-page/albums/");
            var files = Request.Files;
            AdminServices.Albums.UploadCafeAlbumPhotos(files, AlbumId, mapPath);
            return Json("Загрузка завершена");
        }
        [HttpPost]
        public ActionResult DeleteSlider(int SliderId)
        {
            string mapPath = Server.MapPath("~/Content/Images/cafe-page/albums/");
            AdminServices.Albums.DeleteSlider(SliderId, mapPath);
            return RedirectToAction("management", "cafe");
        }
        [HttpPost]
        public ActionResult GetCafeAlbumPhotosJson(int AlbumId)
        {
            try
            {
                var photoList = AdminServices.Albums.GetCafeAlbumPhotos(AlbumId);
                return Json(photoList);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", ex.Message });
            }
        }
        [HttpPost]
        public ActionResult DeleteCafePhotoJson(int PhotoId)
        {
            string mapPath = Server.MapPath("~/Content/Images/cafe-page/albums/");
            try
            {
                AdminServices.Albums.DeleteCafeAlbumPhoto(PhotoId, mapPath);
                return Json("Успешно удалено");
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", ex.Message });
            }
        }
    }
}