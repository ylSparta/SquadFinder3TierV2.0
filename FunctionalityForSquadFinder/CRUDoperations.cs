using System;
using System.Collections.Generic;
using System.Linq;
using SquadFinder3Tier;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SquadFinder3Tier.Services;

namespace FunctionalityForSquadFinder
{
    public class CRUDoperations
    {
        private SquadService _squadService = new SquadService();
        private MemberService _memberService = new MemberService();


        public Squad SelectedSquad { get; private set; }
        public SquadMembers SelectedSquadMember { get; private set; }
        public Members SelectedMember { get; private set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        //CREATE methods 
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

        public void CreateSquadMember(Members member, Squad squad)
        {
            using (var db = new TeamFinder3TAppContext())
            {
                var result1 = db.Members.Where(m => m.MemberId == member.MemberId);
                var result2 = db.Squad.Where(s => s.SquadId == squad.SquadId);
                if (result1.Count() == 1 && result2.Count() == 1)
                {
                    SquadMembers squaMember = new SquadMembers()
                    {
                        SquadMemberId = $"{member.MemberId}-{squad.SquadId}",
                        MemberId = member.MemberId,
                        SquadId = squad.SquadId
                    };
                    db.SquadMembers.Add(squaMember);
                    db.SaveChanges();
                }
            }
        }

        public void CreateSquad(string squadId, string squadLeader, int numberOfSquadMembers, string sport)
        {
            var result = _squadService.FindSquad(squadId);
            if (result == null)
            {
                Squad squa = new Squad()
                {
                    SquadId = squadId,
                    SquadLeader = squadLeader,
                    NoOfSquadMembers = numberOfSquadMembers,
                    Sport = sport
                };
                _squadService.AddSquad(squa);
                _squadService.SaveSquad();
                
            }
        }

        //UPDATE methods 
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

        public void UpdateSquadMember(string squadMemberId, string squadId, string memberId)
        {
            using (var db = new TeamFinder3TAppContext())
            {
                SelectedSquadMember = db.SquadMembers.Where(s => s.SquadId == squadId).FirstOrDefault();
                SelectedSquadMember.SquadId = squadId;
                SelectedSquadMember.MemberId = memberId;
                // write changes to database
                db.SaveChanges();
            }
        }

        public void UpdateSquad(string squadId, string squadLeader, int numberOfSquadMembers, string sport)
        {
            SelectedSquad = _squadService.FindSquad(squadId);
            if (SelectedSquad != null)
            {
                SelectedSquad.SquadLeader = squadLeader;
                SelectedSquad.NoOfSquadMembers = numberOfSquadMembers;
                SelectedSquad.Sport = sport;
                _squadService.UpdateSquad(SelectedSquad);
                _squadService.SaveSquad();
            }
                
        }


        //DELETE methods 
        public void DeleteMember(Members member)
        {
            SelectedMember = _memberService.FindMember(member.MemberId);
            _memberService.DeleteMember(SelectedMember);
            _memberService.SaveMember();
        }

        public void DeleteSquadMember()
        {
            using (var db = new TeamFinder3TAppContext())
            {
                db.SquadMembers.Remove(SelectedSquadMember);
                db.SaveChanges();
            }
        }

        public void DeleteSquad(Squad squad)
        {
            SelectedSquad = _squadService.FindSquad(squad.SquadId);
            _squadService.DeleteSquad(SelectedSquad);
            _squadService.SaveSquad();
        }

        //SELECTION methods 
        public void SetSelectedMember(object selectedMember)
        {
            SelectedMember = (Members)selectedMember;
        }

        public void SetSelectedSquadMember(object selectedSquadMember)
        {
            SelectedSquadMember = (SquadMembers)selectedSquadMember;
        }

        public void SetSelectedSquad(object selectedSquad)
        {
            SelectedSquad = (Squad)selectedSquad;
        }

        //Get the data from each table 
        public List<Members> GetAllMembers()
        {
            return _memberService.GetMembers();
     
        }

        public List<SquadMembers> GetAllSquadMembers(string squadId)
        {
            using (var db = new TeamFinder3TAppContext())
            {
                var squadMembers = db.SquadMembers.Where(s => s.SquadId == squadId).ToList();
                return squadMembers;
            }
        }

        public List<Squad> GetAllSquads()
        { 
            return _squadService.GetSquads();    
        }

        

        
    }
}
