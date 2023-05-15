using System.Linq.Expressions;
using Devon4Net.Application.WebAPI.Domain.Entities;
using Devon4Net.Domain.UnitOfWork.Repository;

namespace Devon4Net.Application.WebAPI.Domain.RepositoryInterfaces
{
    /// <summary>
    /// QueueRepository interface
    /// </summary>
    public interface IQueueRepository : IRepository<Queue>
    {
        /// <summary>
        /// GetQueue
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IList<Queue>> GetQueue(Expression<Func<Queue, bool>> predicate = null);

        /// <summary>
        /// GetQueueById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Queue> GetQueueById(int id);

        /// <summary>
        /// Create
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
        Task<Queue> Create(string logo, string name, string description, string link, int? attentionTime, string openTime, string closeTime, bool? started, bool? closed, int? userId);

        /// <summary>
        /// DeleteQueueById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteQueueById(int id);
    }
}