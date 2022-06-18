using System;
using System.Collections.Generic;

namespace tets_bogdan.Models
{
    public partial class Competition
    {
        public Competition()
        {
            Teams = new HashSet<Team>();
        }

        public int Id { get; set; }
        public int? CompetitionTypeId { get; set; }
        public DateTime? Date { get; set; }
        public string? SelectCategoryId { get; set; }
        public string? Place { get; set; }
        public int? StageTypeId { get; set; }

        public virtual CompetitionType? CompetitionType { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
