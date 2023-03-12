using AnılBurakYamaner_Proje.Common.Enums;
using AnılBurakYamaner_Proje.Core.Entity;
using AnılBurakYamaner_Proje.Core.Repository;
using AnılBurakYamaner_Proje.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace AnılBurakYamaner_Proje.Service.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : CoreEntity
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        private DbSet<T> _entities;

        public DbSet<T> Entities
        {
            get 
            { 
                if(_entities == null) 
                    _entities = _context.Set<T>();
                return _entities;
            }
          
        }

        public IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        //Lampta ile yazım şekli. üsteki de normal yazım şekli....
        public IQueryable<T> TableNoTracking => Entities.AsNoTracking();

        
        public async Task<T> Add(T item)
        {
            try
            {
                if (item == null)
                    return null;

                await Entities.AddAsync(item);

                if (await Save() > 0)
                    return item;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddRange(List<T> items)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    await Entities.AddRangeAsync(items);
                    int result = await Save();
                    if (result == items.Count())
                    {
                        ts.Complete();
                        return result > 0;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Update(T item)
        {
            try
            {
                if (item == null)
                    return null;

                Entities.Update(item);

                if (await Save() > 0)
                    return item;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateRange(List<T> items)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    Entities.UpdateRange(items);
                    int result = await Save();
                    if (result == items.Count())
                    {
                        ts.Complete();
                        return result > 0;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate) => await Entities.AnyAsync(predicate);


        public IQueryable<T> GetActive() => Entities.Where(x => x.Status != Status.Deleted).AsQueryable();

        public async Task<T> GetByDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeParameters)
        {
            IQueryable<T> queryable = TableNoTracking;
            foreach (Expression<Func<T, object>> includeParameter in includeParameters)
            {
                queryable = queryable.Include(includeParameter);
            }
            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetById(Guid id, params Expression<Func<T, object>>[] includeParameters)
        {
            IQueryable<T> queryable = TableNoTracking;
            foreach (Expression<Func<T, object>> includeParameter in includeParameters)
            {
                queryable = queryable.Include(includeParameter);
            }
            return await queryable.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<T> GetDefault(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[]
            includeParameters)
        {
            IQueryable<T> queryable = TableNoTracking;
            foreach (Expression<Func<T, object>> includeParameter in includeParameters)
            {
                queryable = queryable.Include(includeParameter);
            }
            return queryable.Where(predicate);
        }

        public async Task<bool> Remove(T item)
        {
            item.Status = Status.Deleted;
            if (await Update(item) != null)
                return true;
            else
                return false;
        }

        public async Task<bool> RemoveAll(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var collection = GetDefault(predicate);
                List<T> items = new List<T>();
                foreach (var item in collection)
                {
                    item.Status = Status.Deleted;
                    items.Add(item);
                }
                return await UpdateRange(items);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();

        public async Task<bool> Activate(Guid id)
        {
            T activated = await GetById(id);
            activated.Status = Status.Active;
            if (await Update(activated) != null)
                return true;
            else
                return false;
        }

       
    }
}
