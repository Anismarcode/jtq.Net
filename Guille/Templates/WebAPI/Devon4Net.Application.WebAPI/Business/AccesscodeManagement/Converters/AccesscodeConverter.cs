using Devon4Net.Application.WebAPI.Business.AccesscodeManagement.Dto;
using Devon4Net.Application.WebAPI.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Business.AccesscodeManagement.Converters
{
    /// <summary>
    /// AccesscodeConverter
    /// </summary>
    public class AccesscodeConverter
    {
        /// <summary>
        /// ModelToDto transformation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static AccesscodeDto ModelToDto(Accesscode item)
        {
            if (item == null) return new AccesscodeDto();

            return new AccesscodeDto
            {
                Id = item.Id,
                CreatedTime = item.CreatedTime,
                StartTime = item.StartTime,
                EndTime = item.EndTime,
                Status = item.Status,
                QueueId = item.QueueId,
                UserId = item.UserId
            };
        }
    }

}
