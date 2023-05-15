using System.Linq.Expressions;
using Devon4Net.Application.WebAPI.Business.QueueManagement.Dto;
using Devon4Net.Application.WebAPI.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Business.QueuesManagement.Service
{
    public interface IQueueService
    {
        /// <summary>
        /// GetQueue
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<QueueDto>> GetQueue(Expression<Func<Queue, bool>> predicate = null);

        /// <summary>
        /// GetQueueById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Queue> GetQueueById(int id);

        /// <summary>
        /// CreateQueue
        /// </summary>
        /// <param name="logo"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="attentionTime"></param>
        /// <param name="openTime"></param>
        /// <param name="closeTime"></param>
        /// <param name="started"></param>
        /// <param name="closed"></param>
        /// <param name="userId"></param>>
        /// <returns></returns>
        Task<Queue> CreateQueue(string logo, string name, string description, string link, int? attentionTime, string openTime, string closeTime, bool? started, bool? closed, int? userId);

        /// <summary>
        /// DeleteQueueById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteQueueById(int id);

        /// <summary>
        /// ModifyQueueById
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
        Task<Queue> ModifyQueueById(int id, string logo, string name, string description, string link, int? attentionTime, string openTime, string closeTime, bool? started, bool? closed, int? userId);
    }
}