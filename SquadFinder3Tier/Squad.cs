using System;
using System.Collections.Generic;

namespace SquadFinder3Tier
{
    public partial class Squad
    {
        public Squad()
        {
            SquadMembers = new HashSet<SquadMembers>();
        }

        public string SquadId { get; set; }
        public string SquadLeader { get; set; }
        public int? NoOfSquadMembers { get; set; }
        public string Sport { get; set; }

        public virtual ICollection<SquadMembers> SquadMembers { get; set; }

        public override string ToString()
        {
            return $"Squad ID: {SquadId}, Squad Leader: {SquadLeader}, Squad Size: {NoOfSquadMembers}, Sport: {Sport}"; 

        }
    }
}
