using System.ComponentModel.DataAnnotations;

namespace Devon4Net.Application.WebAPI.Business.UserManagement.Dto
{
    public class UserDto
    {
        /// <summary>
        /// the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// the Username
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// the Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}