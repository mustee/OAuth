using System.Threading.Tasks;

namespace OAuth.Repository
{
    public interface IRepository<T, Tid>
    {
        Task<Tid> Add(T entity);

        Task<int> Remove(Tid id);

        Task<int> Update(T entity);

        Task<T> Get(Tid id);
    }
}
