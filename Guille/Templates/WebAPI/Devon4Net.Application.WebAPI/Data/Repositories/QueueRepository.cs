using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Devon4Net.Application.WebAPI.Business.UsersManagement.Service;
using Devon4Net.Application.WebAPI.Domain.Database;
using Devon4Net.Application.WebAPI.Domain.Entities;
using Devon4Net.Application.WebAPI.Domain.RepositoryInterfaces;
using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace Devon4Net.Application.WebAPI.Data.Repositories
{
    /// <summary>
    /// Repository implementation for the Queue
    /// </summary>
    public class QueueRepository : Repository<Queue>, IQueueRepository
    {

        private readonly IUserService _userService;
        private MyContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public QueueRepository(MyContext context, IUserService userService) : base(context)
        {
            _userService = userService;
            _context = context;
        }

        /// <summary>
        /// Get Queue method
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public Task<IList<Queue>> GetQueue(Expression<Func<Queue, bool>> predicate = null)
        {
            Devon4NetLogger.Debug("GetQueue method from QueueRepository Queueervice");
            return Get(predicate);
        }

        /// <summary>
        /// Gets the Queue by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Queue> GetQueueById(int id)
        {
            Devon4NetLogger.Debug($"GetQueueById method from repository Queueervice with value : {id}");
            return GetFirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Creates the Queue
        /// </summary>
        /// <param name="logo"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="attentionTime"></param>
        /// <param name="openTime"></param>
        /// <param name="closeTime"></param>
        /// <param name="started"></param>
        /// <param name="closed"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<Queue> Create(string logo, string name, string description, string link, int? attentionTime, string openTime, string closeTime, bool? started, bool? closed, int? userId)
        {
            Devon4NetLogger.Debug($"SetQueue method from repository Queueervice with value : {name}");
            //Si el userId es distinto de null se busca al usuario correspondiente, si es null, el usuario también lo será
            //Task<T>.Result devuelve T, en este caso Task<User>.Result = User
            User user = userId != null ? _userService.GetUserById((int)userId).Result : null;
            Queue queue = new Queue{Logo = logo, Name = name, Description = description, Link = link, AttentionTime = attentionTime, OpenTime = openTime,
             CloseTime = closeTime, Started = started, Closed = closed, UserId = userId};
            var result = Create(queue);

            queue.User = user;

            return result;
        }

        /// <summary>
        /// Deletes the Queue by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteQueueById(int id)
        {
            Devon4NetLogger.Debug($"DeleteQueueById method from repository Queueervice with value : {id}");
            var deleted = await Delete(t => t.Id == id).ConfigureAwait(false);

            if (deleted)
            {
                return id;
            }

            throw  new ArgumentException($"The Queue entity {id} has not been deleted.");
        }
    }
}