using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DataAccess
{
    public class EfRepository<T> where T:class 
    {
        protected pmsEntities Entities { get; set; }

        protected DbSet<T> DbSet { get { return Entities.Set<T>(); } }

        public EfRepository()
        {
            Entities= new pmsEntities();
            
        }
        public virtual IList<T> GetAll()
        {
            return DbSet.ToList();

        }

        public virtual IList<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry entry = Entities.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = Entities.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Remove(T entity)
        {
            DbEntityEntry dbEntityEntry = Entities.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Remove(int id)
        {
            T entity = GetById(id);
            if (entity == null)
            {
                return;
            }
            Remove(entity);


        }
    }
}
