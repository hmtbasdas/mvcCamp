using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();

        public List<Category> GetAllBL()
        {
            return repo.List();
        }
        public void CategoryAddBL(Category item)
        {
            if (item.CategoryName == "" || item.CategoryName.Length <= 3 || 
                item.CategoryDescription == "" || item.CategoryName.Length >= 51)
            {
                //hata mesajı
            }
            else
            {
                repo.Insert(item);
            }
        }
    }
}
