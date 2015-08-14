using System;
using OAuth.Data.Models;
using OAuth.Data;
using System.Threading.Tasks;
using OAuth.Data.DbScripts;

namespace OAuth.Repository.Impl
{
    public class UserRepository : RepositoryBase<User, long>, IUserRepository
    {
        public UserRepository(IDataAccess dataAccess)
            :base(dataAccess)
        {
        }

        public override Task<long> Add(User entity)
        {
            return dataAccess.Execute<long>(DbScripts.User.Insert, new { entity.UserName, entity.SecurityStamp, entity.PasswordHash });
        }

        public Task<User> FindByExternalLogin(string loginProvider, string providerKey)
        {
            return dataAccess.Execute<User>(DbScripts.User.FindByExternalLogin, new { LoginProvider = loginProvider, ProviderKey = providerKey });
        }

        public Task<User> FindByUserName(string userName)
        {
            return dataAccess.Find<User>(DbScripts.User.FindByUserName, new { Username = userName });
        }

        public override Task<User> Get(long id)
        {
            return dataAccess.Find<User>(DbScripts.User.Find, new { Id = id });
        }

        public override Task<int> Remove(long id)
        {
            return dataAccess.Execute<int>(DbScripts.User.Delete, new { Id = id });
        }       

        public override Task<int> Update(User entity)
        {
            return dataAccess.Execute<int>(DbScripts.User.Update, new {entity.Id, entity.UserName, entity.SecurityStamp, entity.PasswordHash });
        }
    }
}
