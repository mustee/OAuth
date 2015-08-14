using System;
using OAuth.Data.Models;
using System.Threading.Tasks;

namespace OAuth.Repository
{
    public interface IUserRepository : IRepository<User, long>
    {
        Task<User> FindByUserName(string userName);

        Task<User> FindByExternalLogin(string loginProvider, string providerKey);
    }
}
