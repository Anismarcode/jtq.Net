using System;
using System.Collections.Generic;

namespace Devon4Net.Application.WebAPI.Domain.Entities
{
    public partial class Accesscode
    {
        public int Id { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; }
        public int? QueueId { get; set; }
        public int? UserId { get; set; }
        public string Code { get; set; }

        public virtual Queue Queue { get; set; }
        public virtual User User { get; set; }
    }
}
