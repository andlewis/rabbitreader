using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Linq.Expressions;

namespace RabbitReader.Repository
{
    public class RepositoryBase<C> : IDisposable
       where C : DbContext, new()
    {
        private C db;

        public virtual C DataContext
        {
            get
            {
                db = new C();
                db.Configuration.LazyLoadingEnabled = false;
                return db;
            }
        }

        public virtual T Get<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            if (predicate != null)
            {
                using (db)
                    return db.Set<T>().Where(predicate).SingleOrDefault();
            }
            else
            {
                throw new ApplicationException("Predicate value must not be null");
            }
        }

        //public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate)
        //{
        //    try
        //    {
        //        return db.Set<T>().Where(predicate);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return null;
        //}

        //public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, bool>> orderBy)
        //{
        //    try
        //    {
        //        return GetList(predicate).OrderBy(orderBy);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return null;
        //}

        //public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> orderBy)
        //{
        //    try
        //    {
        //        return GetList<T>().OrderBy(orderBy);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return null;
        //}

        //public virtual OperationStatus Save<T>(T entity) where T: class
        //{
        //    OperationStatus opStatus = new OperationStatus { Status = true };
        //    try
        //    {
        //        opStatus.Status = db.SaveChanges() > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        opStatus = OperationStatus.CreateFromException("Error Saving", ex);
        //    }

        //}

        //public virtual OperationStatus Update<T>(T entity, params string[] props) where T : class
        //{
        //    OperationStatus opStatus = new OperationStatus { Status = true };
        //    try
        //    {
        //        db.Set<T>().Attach(entity);
        //        opStatus.Status = db.SaveChanges() > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        opStatus = OperationStatus.CreateFromException("Error Saving", ex);
        //    }

        //}



        public void Dispose()
        {
            if (db != null) db.Dispose();
        }
    }
}
