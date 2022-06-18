using System;
using System.Collections.Generic;

namespace tets_bogdan.Models
{
    public partial class Participant
    {
        public Participant()
        {
            TeamFirstParticipants = new HashSet<Team>();
            TeamSecondParticipants = new HashSet<Team>();
        }

        public int Id { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Mesto { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Documents { get; set; }
        public string? name { get; set; }

        public virtual ICollection<Team> TeamFirstParticipants { get; set; }
        public virtual ICollection<Team> TeamSecondParticipants { get; set; }
    }
}
