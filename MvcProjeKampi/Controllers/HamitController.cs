using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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