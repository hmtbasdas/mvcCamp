using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IMySkillsService
    {
        void AddSkill(MySkills skills);
        void DeleteSkill(MySkills skills);
        void UpdateSkill(MySkills skills);
        MySkills GetByID(int id);
        List<MySkills> GetList();
    }
}
