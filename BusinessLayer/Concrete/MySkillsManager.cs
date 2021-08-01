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
    public class MySkillsManager : IMySkillsService
    {
        IMySkillsDal _mySkillsDal;

        public MySkillsManager(IMySkillsDal mySkillsDal)
        {
            _mySkillsDal = mySkillsDal;
        }

        public List<MySkills> GetList()
        {
            return _mySkillsDal.List();
        }
    }
}
