using System.Linq.Expressions;
using Devon4Net.Application.WebAPI.Business.QueueManagement.Converters;
using Devon4Net.Application.WebAPI.Business.QueueManagement.Dto;
using Devon4Net.Application.WebAPI.Business.QueueManagement.Exceptions;
using Devon4Net.Application.WebAPI.Domain.Database;
using Devon4Net.Application.WebAPI.Domain.Entities;
using Devon4Net.Application.WebAPI.Domain.RepositoryInterfaces;
using Devon4Net.Domain.UnitOfWork.Service;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Devon4Net.Infrastructure.Common;

namespace Devon4Net.Application.WebAPI.Business.QueuesManagement.Service
{
    public class QueueService : Service<MyContext>, IQueueService
    {
        /// <summary>
        /// Queue service implementation
        /// </summary>
    
        private readonly IQueueRepository _QueueRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uoW"></param>
        public QueueService(IUnitOfWork<MyContext> uoW) : base(uoW)
        {
            _QueueRepository = uoW.Repository<IQueueRepository>();
        }

        /// <summary>
        /// Gets the Queue
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<QueueDto>> GetQueue(Expression<Func<Queue, bool>> predicate = null)
        {
            Devon4NetLogger.Debug("GetQueue method from service Queueservice");
            var result = await _QueueRepository.GetQueue(predicate).ConfigureAwait(false);
            return result.Select(QueueConverter.ModelToDto);
        }

        /// <summary>
        /// Gets the Queue by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Queue> GetQueueById(int id)
        {
            Devon4NetLogger.Debug($"GetQueueById method from service Queueservice with value : {id}");
            return _QueueRepository.GetQueueById(id);
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
        public Task<Queue> CreateQueue(string logo, string name, string description, string link, int? attentionTime, string openTime, string closeTime, bool? started, bool? closed, int? userId)
        {
            Devon4NetLogger.Debug($"SetQueue method from service Queueservice with value : {logo}, {name}");

            if (string.IsNullOrEmpty(logo) || string.IsNullOrWhiteSpace(logo))
            {
                throw new ArgumentException("The 'logo' field can not be null.");
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The 'name' field can not be null.");
            }

            if (string.IsNullOrEmpty(description) || string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("The 'description' field can not be null.");
            }

            if (string.IsNullOrEmpty(link) || string.IsNullOrWhiteSpace(link))
            {
                throw new ArgumentException("The 'link' field can not be null.");
            }

            if (string.IsNullOrEmpty(openTime) || string.IsNullOrWhiteSpace(openTime))
            {
                throw new ArgumentException("The 'openTime' field can not be null.");
            }

            if (string.IsNullOrEmpty(closeTime) || string.IsNullOrWhiteSpace(closeTime))
            {
                throw new ArgumentException("The 'closeTime' field can not be null.");
            }

            return _QueueRepository.Create(logo, name, description, link, attentionTime, openTime, closeTime, started, closed, userId);
        }

        /// <summary>
        /// Deletes the Queue by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteQueueById(int id)
        {
            Devon4NetLogger.Debug($"DeleteQueueById method from service Queueservice with value : {id}");
            var Queue = await _QueueRepository.GetFirstOrDefault(t => t.Id == id).ConfigureAwait(false);

            if (Queue == null)
            {
                throw new ArgumentException($"The provided Id {id} does not exists");
            }

            return await _QueueRepository.DeleteQueueById(id).ConfigureAwait(false);
        }

        /// <summary>
        /// Modifies the state of the Queue by id
        /// </summary>
        /// <param name="id"></param>
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
        public async Task<Queue> ModifyQueueById(int id, string logo, string name, string description, string link, int? attentionTime, string openTime, string closeTime, bool? started, bool? closed, int? userId)
        {
            Devon4NetLogger.Debug($"ModifyQueueById method from service Queueservice with value : {id}");
            var Queue = await _QueueRepository.GetFirstOrDefault(t => t.Id == id).ConfigureAwait(false);

            if (Queue == null)
            {
                throw new QueueNotFoundException($"The Queue with id {id} does not exists and is not possible to delete.");
            }

            Queue.Logo = logo;
            Queue.Name = name;
            Queue.Description = description;
            Queue.Link = link;
            Queue.AttentionTime = attentionTime;
            Queue.OpenTime = openTime;
            Queue.CloseTime = closeTime;
            Queue.Started = started;
            Queue.Closed = closed;
            Queue.UserId = userId;

            return await _QueueRepository.Update(Queue).ConfigureAwait(false);
        }
    }
}