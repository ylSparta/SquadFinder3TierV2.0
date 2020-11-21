using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using FunctionalityForSquadFinder;
using SquadFinder3Tier.Services;
using SquadFinder3Tier;
using System.Linq;

namespace SquadFinderTests
{
    public class SquadTests
    {
        private TeamFinder3TAppContext _context;
        private CRUDoperationsForSquad _crudSquad;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options = new DbContextOptionsBuilder<TeamFinder3TAppContext>()
                .UseInMemoryDatabase(databaseName: "FakeTeamFinderDb")
                .Options;
            _context = new TeamFinder3TAppContext(options);
            SquadService squadService = new SquadService(_context);
            _crudSquad = new CRUDoperationsForSquad(squadService);

            



        }
    }
}
