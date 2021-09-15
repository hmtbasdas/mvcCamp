using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        WriterManager wm = new WriterManager(new EFWriterDal());

        WriterValidator writerValidator = new WriterValidator();

        Context com = new Context();

        [HttpGet]
        public ActionResult WriterProfile()
        {
            var writerID = wm.GetByID(writerInfo());
            ViewBag.d = writerInfo();
            return View(writerID);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult validationResult = writerValidator.Validate(writer);
            if (validationResult.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("AllHeading");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public ActionResult MyHeading()
        {
            var values = hm.GetListByWriter(writerInfo());
            return View(values);
        }

        public int writerInfo()
        {
            var p = (string)Session["WriterMail"];
            return com.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),

                                                   }).ToList();

            ViewBag.vlc = categoryValues;

            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writerInfo();
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);

            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString(),

                                                   }).ToList();

            ViewBag.vlc = categoryValues;

            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction(nameof(MyHeading));
        }

        public ActionResult PassiveHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingPassive(HeadingValue);
            return RedirectToAction(nameof(MyHeading));
        }

        public ActionResult AllHeading(int p = 1)
        {
            var headings = hm.GetList().ToPagedList(p, 4);
            return View(headings);
        }
    }
}