using System;
using System.Collections.Generic;
using System.Linq;
using SquadFinder3Tier;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using SquadFinder3Tier.Services;

namespace FunctionalityForSquadFinder
{
    public class CRUDoperationsForSquad
    {
        private SquadService _squadService = new SquadService();
        public Squad SelectedSquad { get; private set; }

        public CRUDoperationsForSquad()
        {
        }

        public CRUDoperationsForSquad(SquadService squaService)
        {
            _squadService = squaService;
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

        public void DeleteSquad(Squad squad)
        {
            SelectedSquad = _squadService.FindSquad(squad.SquadId);
            _squadService.DeleteSquad(SelectedSquad);
            _squadService.SaveSquad();
        }

        public void SetSelectedSquad(object selectedSquad)
        {
            SelectedSquad = (Squad)selectedSquad;
        }

        public List<Squad> GetAllSquads()
        {
            return _squadService.GetSquads();
        }
    }
}
