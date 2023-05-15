using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Devon4Net.Application.WebAPI.Business.QueuesManagement.Service;
using Devon4Net.Application.WebAPI.Business.UsersManagement.Service;
using Devon4Net.Application.WebAPI.Domain.Database;
using Devon4Net.Application.WebAPI.Domain.Entities;
using Devon4Net.Application.WebAPI.Domain.RepositoryInterfaces;
using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Common;

namespace Devon4Net.Application.WebAPI.Data.Repositories
{
    /// <summary>
    /// Repository implementation for the Accesscode
    /// </summary>
    public class AccesscodeRepository : Repository<Accesscode>, IAccesscodeRepository
    {
        private readonly IUserService _userService;
        private readonly IQueueService _queueService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public AccesscodeRepository(MyContext context, IUserService userService, IQueueService queueService) : base(context)
        {
            _userService = userService;
            _queueService = queueService;
        }

        /// <summary>
        /// Get Accesscode method
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<IList<Accesscode>> GetAccesscode(Expression<Func<Accesscode, bool>> predicate = null)
        {
            Devon4NetLogger.Debug("GetAccesscode method from AccesscodeRepository Accesscodeervice");
            return Get(predicate);
        }

        /// <summary>
        /// Gets the Accesscode by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Accesscode> GetAccesscodeById(int id)
        {
            Devon4NetLogger.Debug($"GetAccesscodeById method from repository Accesscodeervice with value : {id}");
            return GetFirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Creates the Accesscode
        /// </summary>
        /// <param name="status"></param>
        /// <param name="queueId"></param>
        /// <param name="userId"></param>
        /// <param name="createdTime"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public Task<Accesscode> Create(DateTime? createdTime, DateTime startTime, DateTime? endTime, string status, int? queueId, int? userId, string code)
        {
            Devon4NetLogger.Debug($"SetAccesscode method from repository Accesscodeervice with value :");
            
            User user = userId != null ? _userService.GetUserById((int)userId).Result : null;
            Queue queue = queueId != null ? _queueService.GetQueueById((int)queueId).Result : null;

            Accesscode accesscode = new Accesscode{Status = status, QueueId = queueId, UserId = userId, CreatedTime = createdTime, StartTime = startTime, EndTime = endTime, Code = code};
            var result = Create(accesscode);
            accesscode.User = user;
            accesscode.Queue = queue;
            return result;
        }

        /// <summary>
        /// Deletes the Accesscode by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAccesscodeById(int id)
        {
            Devon4NetLogger.Debug($"DeleteAccesscodeById method from repository Accesscodeervice with value : {id}");
            var deleted = await Delete(t => t.Id == id).ConfigureAwait(false);

            if (deleted)
            {
                return id;
            }

            throw  new ArgumentException($"The Accesscode entity {id} has not been deleted.");
        }
    }
}