using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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
        IAdminDal adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            this.adminDal = adminDal;
        }

        public void AdminAddBL(Admin item)
        {
            adminDal.Insert(item);
        }

        public void AdminDelete(Admin admin)
        {
            adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            adminDal.Update(admin);
        }

        public Admin GetByID(int id)
        {
            return adminDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
            return adminDal.List();
        }

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
