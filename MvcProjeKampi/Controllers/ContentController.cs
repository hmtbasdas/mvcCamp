using BusinessLayer.Concrete;
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

        [HttpGet]
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = cm.GetListByID(id);
            return View(contentValues);
        }
    }
}