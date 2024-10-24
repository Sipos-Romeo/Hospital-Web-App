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
            this._hospitalAppDbContext = ApplicationDbcontext;
        }

        public IQueryable<T> FindAll()
        {
            return this._hospitalAppDbContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._hospitalAppDbContext.Set<T>().Where(expression);
        }
        public T GetByCondition(Expression<Func<T, bool>> expression)
        {
            return this._hospitalAppDbContext.Set<T>().Where(expression).FirstOrDefault();
        }

        public void Create(T entity)
        {
            this._hospitalAppDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._hospitalAppDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this._hospitalAppDbContext.Set<T>().Remove(entity);
        }
    }
}
