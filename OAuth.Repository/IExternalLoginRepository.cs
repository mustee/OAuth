using Microsoft.AspNet.Identity;
using OAuth.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OAuth.Repository
{
    public interface IExternalLoginRepository : IRepository<ExternalLogin, long>
    {
        Task<IEnumerable<UserLoginInfo>> FindLogins(long userId);

        Task<int> DeleteLogin(long userId, string loginProvider, string providerKey);
    }
}
