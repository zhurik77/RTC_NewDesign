using System;
using System.Collections.Generic;

namespace tets_bogdan.Models
{
    public partial class Trainer
    {
        public Trainer()
        {
            Teams = new HashSet<Team>();
        }

        public int Id { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Mesto { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Documents { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
