using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id);
        void HeadingAdd(Heading item);
        Heading GetByID(int id);
        void HeadingPassive(Heading heading);
        void HeadingActive(Heading heading);
        void HeadingUpdate(Heading heading);
    }
}
