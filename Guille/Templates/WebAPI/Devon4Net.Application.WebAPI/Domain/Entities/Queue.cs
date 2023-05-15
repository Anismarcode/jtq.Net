using System;
using System.Collections.Generic;

namespace Devon4Net.Application.WebAPI.Domain.Entities
{
    public partial class Queue
    {
        public Queue()
        {
            Accesscodes = new HashSet<Accesscode>();
        }

        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int? AttentionTime { get; set; }
        public string OpenTime { get; set; }
        public string CloseTime { get; set; }
        public bool? Started { get; set; }
        public bool? Closed { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Accesscode> Accesscodes { get; set; }
    }
}
