using System;
using System.Collections.Generic;
using System.Text;

namespace SquadFinder3Tier.Services
{
    public interface ISquadService
    {
        public void AddSquad(Squad squad);

        public Squad FindSquad(string squadId);

        public void UpdateSquad(Squad squad);

        public void DeleteSquad(Squad squad);

        public void SaveSquad();

        public List<Squad> GetSquads();
        
    }
}
