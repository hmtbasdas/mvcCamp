using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<Type>
    {
        //CRUD
        //Type Name();
        Type Get(Expression<Func<Type, bool>> filter);
        List<Type> List();
        void Insert(Type item);
        void Update(Type item);
        void Delete(Type item);
        List<Type> List(Expression<Func<Type, bool>> filter);
    }
}
