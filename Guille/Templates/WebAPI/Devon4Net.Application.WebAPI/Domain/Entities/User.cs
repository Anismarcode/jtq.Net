using System;
using System.Collections.Generic;

namespace Devon4Net.Application.WebAPI.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Accesscodes = new HashSet<Accesscode>();
            Queues = new HashSet<Queue>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Accesscode> Accesscodes { get; set; }
        public virtual ICollection<Queue> Queues { get; set; }
    }
}
