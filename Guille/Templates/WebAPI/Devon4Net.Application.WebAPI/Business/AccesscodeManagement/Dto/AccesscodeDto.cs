using System.ComponentModel.DataAnnotations;

namespace Devon4Net.Application.WebAPI.Business.AccesscodeManagement.Dto
{
    public class AccesscodeDto
    {
        /// <summary>
        /// the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// the CreatedTime
        /// </summary>
        [Required]
        public DateTime? CreatedTime { get; set; }

        /// <summary>
        /// the StartTime
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// the EndTime
        /// </summary>
        [Required]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// the Status
        /// </summary>
        [Required]
        public string Status { get; set; }

        /// <summary>
        /// the QueueId
        /// </summary>
        [Required]
        public int? QueueId { get; set; }

        /// <summary>
        /// the UserId
        /// </summary>
        [Required]
        public int? UserId { get; set; }

        /// <summary>
        /// the Code
        /// </summary>
        [Required]
        public string Code { get; set; }
    }
}