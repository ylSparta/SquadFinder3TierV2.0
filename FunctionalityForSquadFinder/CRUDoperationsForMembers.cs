using System;
using System.Collections.Generic;
using System.Linq;
using SquadFinder3Tier;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SquadFinder3Tier.Services;

namespace FunctionalityForSquadFinder
{
    public class CRUDoperationsForMembers
    {
        private MemberService _memberService = new MemberService();

        public Members SelectedMember { get; private set; }

        static void Main(string[] args)
        {
            
        }

        public CRUDoperationsForMembers()
        {
            
        }

        public CRUDoperationsForMembers(MemberService memService)
        {
            _memberService = memService;
        }
        
        public void CreateMember(string memberId, string fName, string lName)
        {
            var result = _memberService.FindMember(memberId);
            if (result == null)
            {
                Members newMember = new Members()
                {
                    MemberId = memberId,
                    FirstName = fName,
                    LastName = lName
                };
                _memberService.AddMember(newMember);
                _memberService.SaveMember();
            }
            
        }
       
        public void UpdateMember(string fName, string lName, string memberId)
        {
            SelectedMember = _memberService.FindMember(memberId);
            if (SelectedMember != null)
            {
                SelectedMember.FirstName = fName;
                SelectedMember.LastName = lName;
                _memberService.UpdateMember(SelectedMember);
                _memberService.SaveMember();
            }       
        }

      
        public void DeleteMember(Members member)
        {
            SelectedMember = _memberService.FindMember(member.MemberId);
            _memberService.DeleteMember(SelectedMember);
            _memberService.SaveMember();
        }

        
        public void SetSelectedMember(object selectedMember)
        {
            SelectedMember = (Members)selectedMember;
        }

        
        public List<Members> GetAllMembers()
        {
            return _memberService.GetMembers();
     
        }

        

        

        

        
    }
}
