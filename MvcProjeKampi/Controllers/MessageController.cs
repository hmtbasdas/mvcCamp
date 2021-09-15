using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        MessageValidator mv = new MessageValidator();

        Context context = new Context();
        public ActionResult Inbox()
        {
            var messageList = mm.GetListInbox(writerMail());
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            var messageLst = mm.GetListSendBox(writerMail());
            return View(messageLst);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = mv.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = writerMail();
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            mm.GetByID(id).ReadMessage = true;
            mm.MessageUpdate(mm.GetByID(id));

            var values = mm.GetByID(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        public string writerMail()
        {
            return (string)Session["WriterMail"];
        }
    }
}