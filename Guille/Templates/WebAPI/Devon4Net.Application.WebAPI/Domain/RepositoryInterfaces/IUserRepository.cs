using System.Linq.Expressions;
using Devon4Net.Application.WebAPI.Domain.Entities;
using Devon4Net.Domain.UnitOfWork.Repository;

namespace Devon4Net.Application.WebAPI.Domain.RepositoryInterfaces
{
    /// <summary>
    /// UserRepository interface
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// GetUser
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IList<User>> GetUser(Expression<Func<User, bool>> predicate = null);

        /// <summary>
        /// GetUserById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetUserById(int id);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User> Create(string username, string password);

        /// <summary>
        /// DeleteUserById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteUserById(int id);
    }
}