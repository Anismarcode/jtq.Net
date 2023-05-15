using System.ComponentModel.DataAnnotations;
using Devon4Net.Application.WebAPI.Business.AccesscodeManagement.Dto;
using Devon4Net.Application.WebAPI.Business.AccesscodesManagement.Service;
using Devon4Net.Infrastructure.Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Devon4Net.Application.WebAPI.Business.AccesscodesManagement.Controllers
{
    /// <summary>
    /// Accesscodes controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class AccesscodeController : ControllerBase
    {
        private readonly IAccesscodeService _AccesscodeService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="AccesscodeService"></param>
        public AccesscodeController( IAccesscodeService AccesscodeService)
        {
            _AccesscodeService = AccesscodeService;
        }

        /// <summary>
        /// Gets the entire list of Accesscodes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<AccesscodeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAccesscode()
        {
            Devon4NetLogger.Debug("Executing GetAccesscode from controller AccesscodeController");
            return Ok(await _AccesscodeService.GetAccesscode().ConfigureAwait(false));
        }

        /// <summary>
        /// Gets a Accesscode based on its Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{accesscodeId:int}")]
        [ProducesResponseType(typeof(AccesscodeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetUserById([Required] int accesscodeId)
        {
            Devon4NetLogger.Debug("Executing GetQueueById from controller QueueController");
            return Ok(await _AccesscodeService.GetAccesscodeById(accesscodeId).ConfigureAwait(false));
        }

        /// <summary>
        /// Creates an Accesscode
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(AccesscodeDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create(AccesscodeDto AccesscodeDto)
        {
            Devon4NetLogger.Debug("Executing Create from controller AccesscodeController");
            var result = await _AccesscodeService.CreateAccesscode(AccesscodeDto.CreatedTime, AccesscodeDto.StartTime, AccesscodeDto.EndTime, AccesscodeDto.Status, AccesscodeDto.QueueId, AccesscodeDto.UserId, AccesscodeDto.Code).ConfigureAwait(false);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Deletes the Accesscode provided the id
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(AccesscodeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete([Required]int AccesscodeId)
        {
            Devon4NetLogger.Debug("Executing Delete from controller AccesscodeController");
            return Ok(await _AccesscodeService.DeleteAccesscodeById(AccesscodeId).ConfigureAwait(false));
        }

        /// <summary>
        /// Modifies the done status of the Accesscode provided the data of the Accesscode
        /// In this sample, all the data fields are mandatory
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(AccesscodeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ModifyAccesscode(AccesscodeDto AccesscodeDto)
        {
            Devon4NetLogger.Debug("Executing ModifyAccesscode from controller AccesscodeController");
            if (AccesscodeDto == null || AccesscodeDto.Id == 0)
            {
                return BadRequest("The id of the Accesscode must be provided");
            }
            return Ok(await _AccesscodeService.ModifyAccesscodeById(AccesscodeDto.Id, AccesscodeDto.CreatedTime, AccesscodeDto.StartTime, AccesscodeDto.EndTime, AccesscodeDto.Status, AccesscodeDto.QueueId, AccesscodeDto.UserId, AccesscodeDto.Code).ConfigureAwait(false));
        }
    }
}