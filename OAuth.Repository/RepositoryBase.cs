using System.Threading.Tasks;
using OAuth.Data;

namespace OAuth.Repository
{
    public abstract class RepositoryBase<T, Tid> : IRepository<T, Tid>
    {
        protected IDataAccess dataAccess;
        protected RepositoryBase(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public abstract Task<Tid> Add(T entity);

        public abstract Task<T> Get(Tid id);

        public abstract Task<int> Remove(Tid id);

        public abstract Task<int> Update(T entity);
    }
}
