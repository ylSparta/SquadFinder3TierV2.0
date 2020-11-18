using System;
using System.Collections.Generic;

namespace SquadFinder3Tier
{
    public partial class Members
    {
        public Members()
        {
            SquadMembers = new HashSet<SquadMembers>();
        }

        public string MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<SquadMembers> SquadMembers { get; set; }

        public override string ToString()
        {
            return $"MemberID: {MemberId}, First Name: {FirstName}, Last Name: {LastName}";

        }
    }
}
