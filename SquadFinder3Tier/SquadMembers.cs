using System;
using System.Collections.Generic;

namespace SquadFinder3Tier
{
    public partial class SquadMembers
    {
        public string SquadMemberId { get; set; }
        public string SquadId { get; set; }
        public string MemberId { get; set; }

        public virtual Members Member { get; set; }
        public virtual Squad Squad { get; set; }

        public override string ToString()
        {
            return $"Squad Member ID: {SquadMemberId}, Member ID: {MemberId}, SquadID: {SquadId}";

        }
    }
}
