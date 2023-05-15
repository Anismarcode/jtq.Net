using System.Linq.Expressions;
using Devon4Net.Application.WebAPI.Business.AccescodeManagement.Exceptions;
using Devon4Net.Application.WebAPI.Business.AccesscodeManagement.Converters;
using Devon4Net.Application.WebAPI.Business.AccesscodeManagement.Dto;
using Devon4Net.Application.WebAPI.Business.QueuesManagement.Service;
using Devon4Net.Application.WebAPI.Domain.Database;
using Devon4Net.Application.WebAPI.Domain.Entities;
using Devon4Net.Application.WebAPI.Domain.RepositoryInterfaces;
using Devon4Net.Domain.UnitOfWork.Service;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Devon4Net.Infrastructure.Common;

namespace Devon4Net.Application.WebAPI.Business.AccesscodesManagement.Service
{
    public class AccesscodeService : Service<MyContext>, IAccesscodeService
    {
        /// <summary>
        /// Accesscode service implementation
        /// </summary>
        private readonly IAccesscodeRepository _accesscodeRepository;

        private readonly IQueueService _queueService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uoW"></param>
        public AccesscodeService(IUnitOfWork<MyContext> uoW, IQueueService queueService) : base(uoW)
        {
            _accesscodeRepository = uoW.Repository<IAccesscodeRepository>();
            _queueService = queueService;
        }

        /// <summary>
        /// Gets the Accesscode
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AccesscodeDto>> GetAccesscode(Expression<Func<Accesscode, bool>> predicate = null)
        {
            Devon4NetLogger.Debug("GetAccesscode method from service Accesscodeservice");
            var result = await _accesscodeRepository.GetAccesscode(predicate).ConfigureAwait(false);
            return result.Select(AccesscodeConverter.ModelToDto);
        }

        /// <summary>
        /// Gets the Accesscode by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Accesscode> GetAccesscodeById(int id)
        {
            Devon4NetLogger.Debug($"GetAccesscodeById method from service Accesscodeservice with value : {id}");
            return _accesscodeRepository.GetAccesscodeById(id);
        }

        /// <summary>
        /// Creates the Accesscode
        /// </summary>
        /// <param name="createdTime"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="status"></param>
        /// <param name="queueId"></param>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<Accesscode> CreateAccesscode(DateTime? createdTime, DateTime startTime, DateTime? endTime, string status, int? queueId, int? userId, string code)
        {
            Devon4NetLogger.Debug($"SetAccesscode method from service Accesscodeservice with value : {createdTime}, {startTime}, {endTime}, {status}, {queueId}, {userId}, {code}");

            if (startTime == DateTime.MinValue)
            {
                throw new ArgumentException("The 'startTime' field can not be null.");
            }

            if (string.IsNullOrEmpty(status) || string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("The 'status' field can not be null.");
            }

            if (string.IsNullOrEmpty(status) || string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("The 'status' field can not be null.");
            }

            if(userId.Equals(_queueService.GetQueueById((int)queueId).Result.UserId))
            {
                throw new ArgumentException("An employee cannot request an access code to a queue he's owner of.");
            }

            if (string.IsNullOrEmpty(code) || string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("The 'code' field can not be null.");
            }

            return _accesscodeRepository.Create(createdTime, startTime, endTime, status, queueId, userId, code);
        }

        /// <summary>
        /// Deletes the Accesscode by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAccesscodeById(int id)
        {
            Devon4NetLogger.Debug($"DeleteAccesscodeById method from service Accesscodeservice with value : {id}");
            var Accesscode = await _accesscodeRepository.GetFirstOrDefault(t => t.Id == id).ConfigureAwait(false);

            if (Accesscode == null)
            {
                throw new ArgumentException($"The provided Id {id} does not exists");
            }

            return await _accesscodeRepository.DeleteAccesscodeById(id).ConfigureAwait(false);
        }

        /// <summary>
        /// Modifies the state of the Accesscode by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createdTime"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="status"></param>
        /// <param name="queueId"></param>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<Accesscode> ModifyAccesscodeById(int id, DateTime? createdTime, DateTime startTime, DateTime? endTime, string status, int? queueId, int? userId, string code)
        {
            Devon4NetLogger.Debug($"ModifyAccesscodeById method from service Accesscodeservice with value : {id}");
            var Accesscode = await _accesscodeRepository.GetFirstOrDefault(t => t.Id == id).ConfigureAwait(false);

            if (Accesscode == null)
            {
                throw new AccesscodeNotFoundException($"The Accesscode with id {id} does not exists and is not possible to delete.");
            }

            Accesscode.CreatedTime = createdTime;
            Accesscode.StartTime = startTime;
            Accesscode.EndTime = endTime;
            Accesscode.Status = status;
            Accesscode.QueueId = queueId;
            Accesscode.UserId = userId;
            Accesscode.Code = code;

            return await _accesscodeRepository.Update(Accesscode).ConfigureAwait(false);
        }
    }
}