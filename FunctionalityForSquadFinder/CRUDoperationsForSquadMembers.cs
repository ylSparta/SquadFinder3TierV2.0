using System;
using System.Collections.Generic;
using System.Linq;
using SquadFinder3Tier;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SquadFinder3Tier.Services;

namespace FunctionalityForSquadFinder
{
    public class CRUDoperationsForSquadMembers
    {
        private SquadMemberService _squadMemberService = new SquadMemberService();
        private MemberService _memberService = new MemberService();
        private SquadService _squadService = new SquadService();



        public SquadMembers SelectedSquadMember { get; private set; }

        public void CreateSquadMember(string memberId, string squadId)
        {
            var result1 = _memberService.FindMember(memberId);
            var result2 = _squadService.FindSquad(squadId);
            if (result1 != null && result2 != null)
            {
                SquadMembers squaMember = new SquadMembers()
                {
                    SquadMemberId = $"{memberId}-{squadId}",
                    MemberId = memberId,
                    SquadId = squadId
                };
                _squadMemberService.AddSquadMember(squaMember);
                _squadMemberService.SaveSquadMember();
            }

        }

        public void UpdateSquadMember(string squadMemberId, string squadId, string memberId)
        {
            SelectedSquadMember = _squadMemberService.FindSquadMembers(squadMemberId);
            if (SelectedSquadMember == null)
            {
                SelectedSquadMember.SquadId = squadId;
                SelectedSquadMember.MemberId = memberId;
                _squadMemberService.UpdateSquadMember(SelectedSquadMember);
                _squadMemberService.SaveSquadMember();
            }

        }

        public void DeleteSquadMember(SquadMembers squadMember)
        {
            SelectedSquadMember = _squadMemberService.FindSquadMembers(squadMember.SquadMemberId);
            _squadMemberService.DeleteSquadMember(SelectedSquadMember);
            _squadMemberService.SaveSquadMember();

        }

        public void SetSelectedSquadMember(object selectedSquadMember)
        {
            SelectedSquadMember = (SquadMembers)selectedSquadMember;
        }

        public List<SquadMembers> GetAllSquadMembers(string squadId)
        {
            return _squadMemberService.GetSquadMembers(squadId);
        }
    }
}
