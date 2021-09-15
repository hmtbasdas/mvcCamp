using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class SkillController : Controller
    {
        MySkillsManager mySkillManager = new MySkillsManager(new EFMySkillsDal());
        public ActionResult Index()
        {
            var skillValues = mySkillManager.GetList();
            return View(skillValues);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(MySkills skills)
        {
            mySkillManager.AddSkill(skills);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult DeleteSkill(int id)
        {
            mySkillManager.DeleteSkill(mySkillManager.GetByID(id));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            return View(mySkillManager.GetByID(id));
        }

        [HttpPost]
        public ActionResult EditSkill(MySkills skills)
        {
            mySkillManager.UpdateSkill(skills);
            return RedirectToAction(nameof(Index));
        }
    }
}