using System;
using System.Collections.Generic;
using System.Text;

namespace SquadFinder3Tier.Services
{
    public interface ISquadMembersService
    {
        public void AddSquadMember(SquadMembers squadMem);

        public SquadMembers FindSquadMembers(string squadmemberId);

        public void DeleteSquadMember(SquadMembers squadMem);

        public void UpdateSquadMember(SquadMembers squadMem);

        public void SaveSquadMember();

        public List<SquadMembers> GetSquadMembers(string squadId);



    }
}
