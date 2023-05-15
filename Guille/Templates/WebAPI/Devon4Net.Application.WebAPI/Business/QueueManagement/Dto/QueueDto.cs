using System.ComponentModel.DataAnnotations;
using Devon4Net.Application.WebAPI.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Business.QueueManagement.Dto
{
    public class QueueDto
    {
        /// <summary>
        /// the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// the Logo
        /// </summary>
        [Required]
        public string Logo { get; set; }

        /// <summary>
        /// the Name
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// the Description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// the Link
        /// </summary>
        [Required]
        public string Link { get; set; }

        /// <summary>
        /// the AttentionTime
        /// </summary>
        [Required]
        public int? AttentionTime { get; set; }

        /// <summary>
        /// the OpenTime
        /// </summary>
        [Required]
        public string OpenTime { get; set; }

        /// <summary>
        /// the CloseTime
        /// </summary>
        [Required]
        public string CloseTime { get; set; }

        /// <summary>
        /// the Started
        /// </summary>
        [Required]
        public bool? Started { get; set; }

        /// <summary>
        /// the Closed
        /// </summary>
        [Required]
        public bool? Closed { get; set; }

        /// <summary>
        /// the UserId
        /// </summary>
        [Required]
        public int? UserId { get; set; }

        /// <summary>
        /// the User
        /// </summary>
        // [Required]
        // public User? User { get; set; }
    }
}