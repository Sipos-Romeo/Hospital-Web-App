using Hospital.Repositories;
using Hospital.Web.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Hospital.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected HospitalAppDbContext _hospitalAppDbContext { get; set; }

        public RepositoryBase(HospitalAppDbContext ApplicationDbcontext)
        {
            _hospitalAppDbContext = ApplicationDbcontext;
        }

        public IQueryable<T> FindAll()
        {
            return _hospitalAppDbContext.Set<T>() ?? Enumerable.Empty<T>().AsQueryable();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _hospitalAppDbContext.Set<T>().Where(expression);
        }

        public T GetByCondition(Expression<Func<T, bool>> expression)
        {
            var result = _hospitalAppDbContext.Set<T>().Where(expression).FirstOrDefault();
            if (result == null)
                throw new InvalidOperationException("Entity not found.");
            return result;
        }


        public void Create(T entity)
        {
            _hospitalAppDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _hospitalAppDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _hospitalAppDbContext.Set<T>().Remove(entity);
        }
    }
}
