using Devon4Net.Application.WebAPI.Business.QueueManagement.Dto;
using Devon4Net.Application.WebAPI.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Business.QueueManagement.Converters
{
    /// <summary>
    /// QueueConverter
    /// </summary>
    public class QueueConverter
    {
        /// <summary>
        /// ModelToDto transformation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static QueueDto ModelToDto(Queue item)
        {
            if (item == null) return new QueueDto();

            return new QueueDto
            {
                Id = item.Id,
                Logo = item.Logo,
                Name = item.Name,
                Description = item.Description,
                Link = item.Link,
                AttentionTime = item.AttentionTime,
                OpenTime = item.OpenTime,
                CloseTime = item.CloseTime,
                Started = item.Started,
                Closed = item.Closed,
                UserId = item.UserId
            };
        }
    }

}
