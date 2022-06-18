using System;
using System.Collections.Generic;

namespace tets_bogdan.Models
{
    public partial class Robot
    {
        public Robot()
        {
            Teams = new HashSet<Team>();
        }

        public int Id { get; set; }
        public string? Photo { get; set; }
        public string? Description { get; set; }
        public string? VideoLink { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
