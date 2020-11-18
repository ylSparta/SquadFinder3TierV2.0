using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SquadFinder3Tier.Services
{
    public class SquadService : ISquadService
    {
        private readonly TeamFinder3TAppContext _context = new TeamFinder3TAppContext();

        public void AddSquad(Squad squad)
        {
            _context.Squad.Add(squad);
        }

        public Squad FindSquad(string squadId)
        {
            return _context.Squad.Where(s => s.SquadId == squadId).FirstOrDefault();        
        }

        public void SaveSquad()
        {
            _context.SaveChanges();
        }

        public List<Squad> GetSquads()
        {
           return _context.Squad.ToList();
        }

        public void DeleteSquad(Squad squad)
        {
            _context.Squad.Remove(squad);
        }

        public void UpdateSquad(Squad squad)
        {
            _context.Squad.Update(squad);
        }

    }
}
