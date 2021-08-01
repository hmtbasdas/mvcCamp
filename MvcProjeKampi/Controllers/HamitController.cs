using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HamitController : Controller
    {
        MySkillsManager mySkillManager = new MySkillsManager(new EFMySkillsDal());
        public ActionResult Index()
        {
            var skillValues = mySkillManager.GetList();
            return View(skillValues);
        }
    }
}