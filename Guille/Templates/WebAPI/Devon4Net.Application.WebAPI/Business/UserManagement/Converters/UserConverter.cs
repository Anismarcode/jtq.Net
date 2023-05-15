using Devon4Net.Application.WebAPI.Business.UserManagement.Dto;
using Devon4Net.Application.WebAPI.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Business.UserManagement.Converters
{
    /// <summary>
    /// UserConverter
    /// </summary>
    public class UserConverter
    {
        /// <summary>
        /// ModelToDto transformation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static UserDto ModelToDto(User item)
        {
            if (item == null) return new UserDto();

            return new UserDto
            {
                Id = item.Id,
                Username = item.Username,
                Password = item.Password
            };
        }
    }

}
