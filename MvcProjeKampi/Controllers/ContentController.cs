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
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetList("");
            if (!string.IsNullOrEmpty(p))
            {
                values = cm.GetList(p);
            }
            return View(values.ToList());
        }

        [HttpGet]
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = cm.GetListByID(id);
            return View(contentValues);
        }
    }
}