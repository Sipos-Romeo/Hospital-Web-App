using Hospital.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hospital.Repositories.Implementation
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbcontext _context;
        private DbSet<T> dbSet;
        private bool disposed = false;
        public GenericRepository(ApplicationDbcontext context)
        {
            _context = context;
            dbSet = new DbSet<T>();
        }
        public void Add(T entity) 
        { 
        dbSet.Add(entity);
        }

        public async Task<T> Addsync(T entity) 
        {
            dbSet.Add(entity);
            return entity;
        }

        public void Dispose() 
        {
            disposed(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) 
        {
            if (this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        IEnumerable<T> IGenericRepository<T>.GetAll(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties)
        {
            throw new NotImplementedException();
        }

        T IGenericRepository<T>.GetById(object id)
        {
            throw new NotImplementedException();
        }

        Task<T> IGenericRepository<T>.GetByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<T>.Add(T entity)
        {
            throw new NotImplementedException();
        }

        Task<T> IGenericRepository<T>.AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<T>.update(T entity)
        {
            throw new NotImplementedException();
        }

        Task<T> IGenericRepository<T>.UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<T>.Delete(T entity)
        {
            throw new NotImplementedException();
        }

        Task IGenericRepository<T>.DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
    public IEnumerable<T> GetAll(Expresion<Func<Task, bool>> filter = null, Func<IQueryable<T>> order)
    {
        IQueryable<T> query = DbSet;
        if (filter != null)
        {
            query = query.Where(filtre);
        }
        foreach (var includeProperty in
            includeProperties.split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }
        if (order != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }

    public async T GetById(object id)
    {
        return await dbSet.FindAsync(id);
    }
    public async Task<T> GetByIDAsync(Object id)
    {
        return await dbSet.FindAsync(id);
    }
    public void Update(T entity)
    {
        dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
    public async Task<T> UpdateAsync(T entity)
    {
        DbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }
    public IEnumerable<T> GetAll(Expresion<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> order)
    {
        throw new NotImplementedException();
    }
}
