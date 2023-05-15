using System.Linq.Expressions;
using Devon4Net.Application.WebAPI.Business.UserManagement.Dto;
using Devon4Net.Application.WebAPI.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Business.UsersManagement.Service
{
    public interface IUserService
    {
        /// <summary>
        /// GetUser
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<UserDto>> GetUser(Expression<Func<User, bool>> predicate = null);

        /// <summary>
        /// GetUserById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetUserById(int id);

        /// <summary>
        /// CreateUser
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surName"></param>
        /// <param name="mail"></param>
        /// <returns></returns>
        Task<User> CreateUser(string username, string password);

        /// <summary>
        /// DeleteUserById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteUserById(int id);

        /// <summary>
        /// ModifyUserById
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surName"></param>
        /// <param name="mail"></param>
        /// <returns></returns>
        Task<User> ModifyUserById(int id, string username, string password);
    }
}