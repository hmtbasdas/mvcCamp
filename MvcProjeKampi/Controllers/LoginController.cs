using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        AdminManager al = new AdminManager();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var adminUser = al.Login(c,admin);

            if (adminUser != null)
            {
                FormsAuthentication.SetAuthCookie(adminUser.AdminUserName, false);
                Session["AdminUserName"] = adminUser.AdminUserName;

                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}