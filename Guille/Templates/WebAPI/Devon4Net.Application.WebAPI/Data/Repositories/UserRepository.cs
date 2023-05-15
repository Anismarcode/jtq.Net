using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Devon4Net.Application.WebAPI.Domain.Database;
using Devon4Net.Application.WebAPI.Domain.Entities;
using Devon4Net.Application.WebAPI.Domain.RepositoryInterfaces;
using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Common;

namespace Devon4Net.Application.WebAPI.Data.Repositories
{
    /// <summary>
    /// Repository implementation for the User
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(MyContext context) : base(context)
        {
        }

        /// <summary>
        /// Get User method
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<IList<User>> GetUser(Expression<Func<User, bool>> predicate = null)
        {
            Devon4NetLogger.Debug("GetUser method from UserRepository Userervice");
            return Get(predicate);
        }

        /// <summary>
        /// Gets the User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User> GetUserById(int id)
        {
            Devon4NetLogger.Debug($"GetUserById method from repository Userervice with value : {id}");
            return GetFirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Creates the User
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<User> Create(string username, string password)
        {
            Devon4NetLogger.Debug($"SetUser method from repository Userervice with value : {username}");
            return Create(new User{Username = username, Password = password});
        }

        /// <summary>
        /// Deletes the User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteUserById(int id)
        {
            Devon4NetLogger.Debug($"DeleteUserById method from repository Userervice with value : {id}");
            var deleted = await Delete(t => t.Id == id).ConfigureAwait(false);

            if (deleted)
            {
                return id;
            }

            throw  new ArgumentException($"The User entity {id} has not been deleted.");
        }
    }
}