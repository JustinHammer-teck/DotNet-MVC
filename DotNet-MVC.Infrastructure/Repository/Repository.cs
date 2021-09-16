using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DotNet_MVC.Application.Common.Repository;
using DotNet_MVC.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace DotNet_MVC.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        internal DbSet<T> DbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.DbSet = _db.Set<T>();
        }

        public T Get(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>,
                IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null)
        {
            IQueryable<T> queryable = DbSet;

            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var incProp in
                    includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(incProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(queryable).ToList();
            }

            return queryable.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null,
            string includeProperties = null)
        {
            IQueryable<T> queryable = DbSet;

            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var incProp in
                    includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    queryable = queryable.Include(incProp);
                }
            }

            return queryable.FirstOrDefault();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Remove(int id)
        {
            T Entity = DbSet.Find(id);

            Remove(Entity);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}