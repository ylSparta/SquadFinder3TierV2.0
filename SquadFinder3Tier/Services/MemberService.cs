using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SquadFinder3Tier.Services
{
    public class MemberService : IMember
    {
        private readonly TeamFinder3TAppContext _context = new TeamFinder3TAppContext();


        public void AddMember(Members member)
        {
            _context.Members.Add(member);
        }

        public void DeleteMember(Members member)
        {
            _context.Members.Remove(member);
        }

        public Members FindMember(string memeberId)
        {
            return _context.Members.Where(m => m.MemberId == memeberId).FirstOrDefault();
        }

        public List<Members> GetMembers()
        {
            return _context.Members.ToList();
        }

        public void SaveMember()
        {
            _context.SaveChanges();
        }

        public void UpdateMember(Members member)
        {
            _context.Members.Update(member);
        }
    }
}
