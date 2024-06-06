﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repositories
{
    public abstract class Repository<T> : IDisposable where T : class
    {
        public ZvonkoModel9 Context { get; set; }
        public DbSet<T> Entities { get; set; }

        public Repository(ZvonkoModel9 context)
        {
            Context = context;
            Entities = Context.Set<T>();
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public virtual int Add(T entity, bool saveChanges = true)
        {
            Entities.Add(entity);
            if (saveChanges)
            {
                return SaveChanges();
            } else return 0;
        }

        public abstract int Update(T entity, bool saveChanges = true);

        public virtual int Remove(T entity, bool saveChanges = true)
        {
            Entities.Attach(entity);
            Entities.Remove(entity);
            if (saveChanges)
            {
                return SaveChanges();
            } else return 0;
        }
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
