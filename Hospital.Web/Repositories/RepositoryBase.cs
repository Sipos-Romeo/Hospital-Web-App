using Hospital.Repositories;
using Hospital.Web.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Hospital.Web.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbcontext ApplicationDbcontext { get; set; }

        public RepositoryBase(ApplicationDbcontext ApplicationDbcontext)
        {
            this.ApplicationDbcontext = ApplicationDbcontext;
        }

        public IQueryable<T> FindAll()
        {
            return this.ApplicationDbcontext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ApplicationDbcontext.Set<T>().Where(expression);
        }
        public T GetByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ApplicationDbcontext.Set<T>().Where(expression).FirstOrDefault();
        }

        public void Create(T entity)
        {
            this.ApplicationDbcontext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.ApplicationDbcontext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.ApplicationDbcontext.Set<T>().Remove(entity);
        }
    }
}
