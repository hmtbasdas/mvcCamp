using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        MessageManager mm = new MessageManager(new EFMessageDal());
        ContactValidator cv = new ContactValidator();

        Context context = new Context();
        public ActionResult Index()
        {
            var contactValue = cm.GetList();
            return View(contactValue);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetByID(id);
            return View(contactValues);
        }
        public PartialViewResult ContactPartial()
        {
            ViewBag.contactValuesCount = cm.GetList().Count;

            ViewBag.messageReceiveCount = context.Messages.Where(x => x.ReadMessage == false && x.ReceiverMail == "admin@gmail.com").Count();
            ViewBag.messageSendCount = mm.GetListSendBox(writerMail()).Count;
            return PartialView();
        }

        public string writerMail()
        {
            return (string)Session["WriterMail"];
        }
    }
}