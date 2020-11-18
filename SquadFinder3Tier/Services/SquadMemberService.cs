using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SquadFinder3Tier.Services
{
    public class SquadMemberService : ISquadMembersService
    {
        private readonly TeamFinder3TAppContext _context = new TeamFinder3TAppContext();

        public void AddSquadMember(SquadMembers squadMem)
        {
            _context.SquadMembers.Add(squadMem);
        }

        public void DeleteSquadMember(SquadMembers squadMem)
        {
            _context.SquadMembers.Remove(squadMem);
        }

        public SquadMembers FindSquadMembers(string squadmemberId)
        {
            return _context.SquadMembers.Where(sm => sm.SquadMemberId == squadmemberId).FirstOrDefault();
        }

        public List<SquadMembers> GetSquadMembers(string squadId)
        {
            return _context.SquadMembers.Where(sm => sm.SquadId == squadId).ToList();
        }

        public void SaveSquadMember()
        {
            _context.SaveChanges();
        }

        public void UpdateSquadMember(SquadMembers squadMem)
        {
            _context.SquadMembers.Update(squadMem);
        }
    }
}
