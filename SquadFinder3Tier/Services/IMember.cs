using System;
using System.Collections.Generic;
using System.Text;

namespace SquadFinder3Tier.Services
{
    public interface IMember
    {
        public void AddMember(Members member);

        public Members FindMember(string memeberId);

        public void UpdateMember(Members member);

        public void DeleteMember(Members member);

        public void SaveMember();

        public List<Members> GetMembers();
    }
}
