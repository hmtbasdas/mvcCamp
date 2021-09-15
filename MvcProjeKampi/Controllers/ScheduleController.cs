using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MvcProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ScheduleController : Controller
    {
		HeadingManager hm = new HeadingManager(new EFHeadingDal());

		[HttpGet]
        public ActionResult Index()
        {
			return View(new CalendarModel());
        }

		public JsonResult GetEvents(DateTime start, DateTime end)
		{
			var viewModel = new CalendarModel();
			var events = new List<CalendarModel>();
			start = DateTime.Today.AddDays(-14);
			end = DateTime.Today.AddDays(-14);

			foreach (var item in hm.GetList())
			{
				events.Add(new CalendarModel()
				{
					title = item.HeadingName,
					start = item.HeadingDate,
					end = item.HeadingDate.AddDays(-14),
					allDay = false
				});

				start = start.AddDays(7);
				end = end.AddDays(7);
			}


			return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
		}
	}
}