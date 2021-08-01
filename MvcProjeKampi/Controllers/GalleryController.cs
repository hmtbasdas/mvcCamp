using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
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
    }
}