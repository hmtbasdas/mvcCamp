﻿using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<Type> : IRepository<Type> where Type:class
    {
        Context context = new Context();
        DbSet<Type> _object;

        public GenericRepository()
        {
            _object = context.Set<Type>();
        }

        public void Delete(Type item)
        {
            _object.Remove(item);
            context.SaveChanges();
        }

        public Type Get(Expression<Func<Type, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void Insert(Type item)
        {
            _object.Add(item);
            context.SaveChanges();
        }

        public List<Type> List()
        {
            return _object.ToList();
        }

        public List<Type> List(Expression<Func<Type, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(Type item)
        {
            context.SaveChanges();
        }
    }
}
