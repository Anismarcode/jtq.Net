using System.Linq.Expressions;
using Devon4Net.Application.WebAPI.Business.UserManagement.Converters;
using Devon4Net.Application.WebAPI.Business.UserManagement.Dto;
using Devon4Net.Application.WebAPI.Business.UserManagement.Exceptions;
using Devon4Net.Application.WebAPI.Domain.Database;
using Devon4Net.Application.WebAPI.Domain.Entities;
using Devon4Net.Application.WebAPI.Domain.RepositoryInterfaces;
using Devon4Net.Domain.UnitOfWork.Service;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Devon4Net.Infrastructure.Common;

namespace Devon4Net.Application.WebAPI.Business.UsersManagement.Service
{
    public class UserService : Service<MyContext>, IUserService
    {
        /// <summary>
        /// User service implementation
        /// </summary>
    
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uoW"></param>
        public UserService(IUnitOfWork<MyContext> uoW) : base(uoW)
        {
            _userRepository = uoW.Repository<IUserRepository>();
        }

        /// <summary>
        /// Gets the User
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UserDto>> GetUser(Expression<Func<User, bool>> predicate = null)
        {
            Devon4NetLogger.Debug("GetUser method from service Userservice");
            var result = await _userRepository.GetUser(predicate).ConfigureAwait(false);
            return result.Select(UserConverter.ModelToDto);
        }

        /// <summary>
        /// Gets the User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<User> GetUserById(int id)
        {
            Devon4NetLogger.Debug($"GetUserById method from service Userservice with value : {id}");
            return _userRepository.GetUserById(id);
        }

        /// <summary>
        /// Creates the User
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Task<User> CreateUser(string username, string password)
        {
            Devon4NetLogger.Debug($"SetUser method from service Userservice with value : {username}, {password}");

            if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("The 'name' field can not be null.");
            }

            if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("The 'surName' field can not be null.");
            }

            return _userRepository.Create(username, password);
        }

        /// <summary>
        /// Deletes the User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteUserById(int id)
        {
            Devon4NetLogger.Debug($"DeleteUserById method from service Userservice with value : {id}");
            var user = await _userRepository.GetFirstOrDefault(t => t.Id == id).ConfigureAwait(false);

            if (user == null)
            {
                throw new ArgumentException($"The provided Id {id} does not exists");
            }

            return await _userRepository.DeleteUserById(id).ConfigureAwait(false);
        }

        /// <summary>
        /// Modifies the state of the User by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<User> ModifyUserById(int id, string username, string password)
        {
            Devon4NetLogger.Debug($"ModifyUserById method from service Userservice with value : {id}");
            var user = await _userRepository.GetFirstOrDefault(t => t.Id == id).ConfigureAwait(false);

            if (user == null)
            {
                throw new UserNotFoundException($"The user with id {id} does not exists and is not possible to delete.");
            }

            user.Username= username;
            user.Password = password;

            return await _userRepository.Update(user).ConfigureAwait(false);
        }
    }
}