﻿using MegaKids.IServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MegaKids.DataModel.Models;
using System.Web.Mvc;
using MegaKids.IServices.Models.Pagination;

namespace MegaKids.WebUI.Controllers
{
    public class GalleryController : DefaultController
    {
        // GET: Gallery
        public ActionResult Index(TableFilterModel data)
        {
            var model = new ModelGallery()
            {
                Seo = MainServices.Modules.GetCurrentPageSeo(CurrentLang.Id, EnumSitePage.Gallery),
                //Albums = MainServices.Albums.GetAlbumList(data,CurrentLang),
                Videos = MainServices.Albums.GetGalleryVideos(CurrentLang)
            };

            return View(model);
        }

        public ActionResult Albums(int id)
        {
            var model = new ModelGallery()
            {
                Album = MainServices.Albums.GetAlbumInfo(CurrentLang, id),
                Photos = MainServices.Albums.GetAlbumPhotos(id)
            };
            return View(model);
        }

        public ActionResult RecentAlbumsPartial(int? currentAlbum)
        {
            var model = MainServices.Albums.GetRecentAlbums(CurrentLang, currentAlbum);
            return PartialView(model);
        }

        public JsonResult GetAlbumList(TableFilterModel data)
        {
            try
            {
                var listPage = MainServices.Albums.GetAlbumList(data, CurrentLang);
                return Json(listPage);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }

        public JsonResult GetVideoList()
        {
            try
            {
                var listPage = MainServices.Albums.GetGalleryVideoList(CurrentLang);
                return Json(listPage);
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", ex.Message });
            }
        }
        public ActionResult TestCollage()
        {
            var Photos = MainServices.Albums.GetAlbumPhotos(43);
            return View(Photos);
        }
    }
}