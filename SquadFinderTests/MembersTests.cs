using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using FunctionalityForSquadFinder;
using SquadFinder3Tier.Services;
using SquadFinder3Tier;

namespace SquadFinderTests
{
    public class Tests
    {
        private TeamFinder3TAppContext _context;
        private CRUDoperationsForMembers _crudMem;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options = new DbContextOptionsBuilder<TeamFinder3TAppContext>()
                .UseInMemoryDatabase(databaseName: "FakeTeamFinderDb")
                .Options;
            _context = new TeamFinder3TAppContext(options);

            MemberService memberService = new MemberService(_context);

            _crudMem = new CRUDoperationsForMembers(memberService);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}