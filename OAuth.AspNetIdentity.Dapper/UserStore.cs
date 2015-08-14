using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using OAuth.Data.Models;
using OAuth.Repository;

namespace OAuth.AspNetIdentity.Dapper
{
    public class UserStore : IUserStore<User>, IUserLoginStore<User>, IUserPasswordStore<User>, IUserSecurityStampStore<User>
    {
        private readonly IUserRepository userRepository;
        private readonly IExternalLoginRepository externalLoginRepository;
        public UserStore(IUserRepository userRepository, IExternalLoginRepository externalLoginRepository)
        {
            this.userRepository = userRepository;
            this.externalLoginRepository = externalLoginRepository;
        }

        public Task AddLoginAsync(User user, UserLoginInfo login)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (login == null)
                throw new ArgumentNullException("login");

            externalLoginRepository.Add(new ExternalLogin { UserId = user.Id, LoginProvider = login.LoginProvider, ProviderKey = login.ProviderKey });
            return Task.FromResult<object>(null);
        }

        public Task CreateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            userRepository.Add(user);
            return Task.FromResult<object>(null);
        }

        public Task DeleteAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");


            userRepository.Remove(user.Id);
            return Task.FromResult<object>(null);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<User> FindAsync(UserLoginInfo login)
        {
            if (login == null)
                throw new ArgumentNullException("login");

            return userRepository.FindByExternalLogin(login.LoginProvider, login.ProviderKey);
        }

        public Task<User> FindByIdAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentNullException("userId");

            long parsedUserId;
            if (!long.TryParse(userId, out parsedUserId))
                throw new ArgumentOutOfRangeException("userId", string.Format("'{0}' is not a valid id.", new { userId }));

            return userRepository.Get(parsedUserId);
        }

        public Task<User> FindByNameAsync(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("userName");

            return userRepository.FindByUserName(userName);
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.Factory.StartNew(() =>
            {
                return (IList<UserLoginInfo>)externalLoginRepository.FindLogins(user.Id).Result;
            });
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetSecurityStampAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return Task.FromResult(user.SecurityStamp);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }

        public Task RemoveLoginAsync(User user, UserLoginInfo login)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            if (login == null)
                throw new ArgumentNullException("login");

            externalLoginRepository.DeleteLogin(user.Id, login.LoginProvider, login.ProviderKey);
            return Task.FromResult<object>(null);
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.PasswordHash = passwordHash;

            return Task.FromResult(0);
        }

        public Task SetSecurityStampAsync(User user, string stamp)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            user.SecurityStamp = stamp;

            return Task.FromResult(0);
        }

        public Task UpdateAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            return userRepository.Update(user);
        }
    }
}
