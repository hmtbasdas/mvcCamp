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

        public void AddSkill(MySkills skills)
        {
            _mySkillsDal.Insert(skills);
        }

        public void DeleteSkill(MySkills skills)
        {
            _mySkillsDal.Delete(skills);
        }

        public MySkills GetByID(int id)
        {
            return _mySkillsDal.Get(x=>x.SkillID == id);
        }

        public List<MySkills> GetList()
        {
            return _mySkillsDal.List();
        }

        public void UpdateSkill(MySkills skills)
        {
            _mySkillsDal.Update(skills);
        }
    }
}
