using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());
        Context context = new Context();

        public ActionResult MyContent()
        {
            var contentValues = cm.GetListByWriter(writerIDInfo());
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.ID = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = writerIDInfo();
            content.ContentStatus = true;

            cm.ContentAdd(content);
            return RedirectToAction(nameof(MyContent));
        }

        public int writerIDInfo()
        {
            var p = (string)Session["WriterMail"];
            return context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}