using System.ComponentModel.DataAnnotations;
using Devon4Net.Application.WebAPI.Business.UserManagement.Dto;
using Devon4Net.Application.WebAPI.Business.UsersManagement.Service;
using Devon4Net.Infrastructure.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Devon4Net.Application.WebAPI.Business.UsersManagement.Controllers
{
    /// <summary>
    /// Users controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userService"></param>
        public UserController( IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets the entire list of users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetUser()
        {
            Devon4NetLogger.Debug("Executing GetUser from controller UserController");
            return Ok(await _userService.GetUser().ConfigureAwait(false));
        }

        /// <summary>
        /// Gets a User based on its Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{userId:int}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetUserById([Required] int userId)
        {
            Devon4NetLogger.Debug("Executing GetQueueById from controller QueueController");
            return Ok(await _userService.GetUserById(userId).ConfigureAwait(false));
        }

        /// <summary>
        /// Creates an user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create(UserDto userDto)
        {
            Devon4NetLogger.Debug("Executing Create from controller UserController");
            var result = await _userService.CreateUser(userDto.Username, userDto.Password).ConfigureAwait(false);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Deletes the user provided the id
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete([Required]int userId)
        {
            Devon4NetLogger.Debug("Executing Delete from controller UserController");
            return Ok(await _userService.DeleteUserById(userId).ConfigureAwait(false));
        }

        /// <summary>
        /// Modifies the done status of the user provided the data of the user
        /// In this sample, all the data fields are mandatory
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ModifyUser(UserDto userDto)
        {
            Devon4NetLogger.Debug("Executing ModifyUser from controller UserController");
            if (userDto == null || userDto.Id == 0)
            {
                return BadRequest("The id of the user must be provided");
            }
            return Ok(await _userService.ModifyUserById(userDto.Id, userDto.Username, userDto.Password).ConfigureAwait(false));
        }
    }
}