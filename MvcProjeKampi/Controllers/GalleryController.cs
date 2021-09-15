using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ifm = new ImageFileManager(new EFImageFileDal());
        public ActionResult Index()
        {
            var imageFiles = ifm.GetList();
            return View(imageFiles);
        }

        [HttpGet]
        public ActionResult AddImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddImage(ImageViewModel viewModel, ImageFile imageFile)
        {
            string folderPath = Server.MapPath("~/AdminLTE-3.0.4/images/");

            try
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/AdminLTE-3.0.4/images/" + fileName + expansion;

                if (Request.Files.Count > 0)
                {
                    var fullPath = Server.MapPath("/AdminLTE-3.0.4/images/") + fileName + expansion;

                    if (System.IO.File.Exists(fullPath))
                    {
                        ViewBag.ActionMessage = "Bu dosya adında bir resim mevcut";
                    }
                    else
                    {
                        Request.Files[0].SaveAs(Server.MapPath(path));
                        imageFile.ImageName = fileName;
                        imageFile.ImagePath = "/AdminLTE-3.0.4/images/" + fileName + expansion;
                        ifm.ImageAdd(imageFile);
                        return RedirectToAction("Index");
                    }
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }
            return View();
        }
    }
}