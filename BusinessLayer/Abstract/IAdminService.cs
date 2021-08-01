using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IAdminService
    {
        Admin Login(Context c,Admin admin);
        Admin Role(Context c, string username);
    }
}
