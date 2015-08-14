using System;
using System.Threading.Tasks;
using OAuth.Data.Models;
using OAuth.Data;
using OAuth.Data.DbScripts;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace OAuth.Repository.Impl
{
    public class ExternalLoginRepository : RepositoryBase<ExternalLogin, long>, IExternalLoginRepository
    {
        public ExternalLoginRepository(IDataAccess dataAccess)
            :base(dataAccess)
        {
        }

        public override Task<long> Add(ExternalLogin entity)
        {
            return dataAccess.Execute<long>(DbScripts.ExternalLogin.Insert, new { entity.UserId, entity.LoginProvider, entity.ProviderKey });
        }

        public Task<int> DeleteLogin(long userId, string loginProvider, string providerKey)
        {
            return dataAccess.Execute<int>(DbScripts.ExternalLogin.DeleteLogin, new { UserId = userId, LoginProvider = loginProvider, ProviderKey = providerKey });
        }

        public Task<IEnumerable<UserLoginInfo>> FindLogins(long userId)
        {
            return dataAccess.FindAll<UserLoginInfo>(DbScripts.ExternalLogin.FindLogins, new { UserId = userId });
        }

        public override Task<ExternalLogin> Get(long id)
        {
            return dataAccess.Find<ExternalLogin>(DbScripts.ExternalLogin.Find, new { Id = id });
        }

        public override Task<int> Remove(long id)
        {
            return dataAccess.Execute<int>(DbScripts.ExternalLogin.Delete, new { Id = id });
        }

        public override Task<int> Update(ExternalLogin entity)
        {
            return dataAccess.Execute<int>(DbScripts.ExternalLogin.Update, new { entity.UserId, entity.LoginProvider, entity.ProviderKey, entity.Id });
        }
    }
}
