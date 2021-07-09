using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class istatistikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());

        Context context = new Context();
        public ActionResult Index()
        {
            ViewBag.toplamKategori = cm.GetList().Count;

            ViewBag.yazilimBaslik = context.Headings.Count(x => x.CategoryID == 12);

            ViewBag.yazarA = context.Writers.Count(x => x.WriterName.Contains("a"));

            int enKategori = context.Headings.Max(x => x.CategoryID);
            ViewBag.enKategoriName = context.Categories.Find(enKategori).CategoryName;

            ViewBag.diffCategoryStatus = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false);
            return View();
        }
    }
}