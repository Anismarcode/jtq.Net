using System.Linq.Expressions;
using Devon4Net.Application.WebAPI.Business.AccesscodeManagement.Dto;
using Devon4Net.Application.WebAPI.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Business.AccesscodesManagement.Service
{
    public interface IAccesscodeService
    {
        /// <summary>
        /// GetAccesscode
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<AccesscodeDto>> GetAccesscode(Expression<Func<Accesscode, bool>> predicate = null);

        /// <summary>
        /// GetAccesscodeById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Accesscode> GetAccesscodeById(int id);

        /// <summary>
        /// CreateAccesscode
        /// </summary>
        /// <param name="createdTime"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="status"></param>
        /// <param name="queueId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Accesscode> CreateAccesscode(DateTime? createdTime, DateTime startTime, DateTime? endTime, string status, int? queueId, int? userId, string code);

        /// <summary>
        /// DeleteAccesscodeById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteAccesscodeById(int id);

        /// <summary>
        /// ModifyAccesscodeById
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createdTime"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="status"></param>
        /// <param name="queueId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Accesscode> ModifyAccesscodeById(int id, DateTime? createdTime, DateTime startTime, DateTime? endTime, string status, int? queueId, int? userId, string code);
    }
}