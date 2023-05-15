using System.Linq.Expressions;
using Devon4Net.Application.WebAPI.Domain.Entities;
using Devon4Net.Domain.UnitOfWork.Repository;

namespace Devon4Net.Application.WebAPI.Domain.RepositoryInterfaces
{
    /// <summary>
    /// AccesscodeRepository interface
    /// </summary>
    public interface IAccesscodeRepository : IRepository<Accesscode>
    {
        /// <summary>
        /// GetAccesscode
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IList<Accesscode>> GetAccesscode(Expression<Func<Accesscode, bool>> predicate = null);

        /// <summary>
        /// GetAccesscodeById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Accesscode> GetAccesscodeById(int id);

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="code"></param>
        /// <param name="status"></param>
        /// <param name="queueId"></param>
        /// <param name="userId"></param>
        /// <param name="createdTime"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        Task<Accesscode> Create(DateTime? createdTime, DateTime startTime, DateTime? endTime, string status, int? queueId, int? userId, string code);

        /// <summary>
        /// DeleteAccesscodeById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteAccesscodeById(int id);
    }
}