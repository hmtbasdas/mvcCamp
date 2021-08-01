using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class AdminManager : IAdminService
    {
        public Admin Login(Context c,Admin admin)
        {
            var adminUser = c.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            return adminUser;
        }

        public Admin Role(Context c, String username)
        {
            var x = c.Admins.FirstOrDefault(y => y.AdminUserName == username);
            return x;
        }
    }
}
