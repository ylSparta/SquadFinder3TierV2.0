using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using FunctionalityForSquadFinder;
using SquadFinder3Tier.Services;
using SquadFinder3Tier;

namespace SquadFinderTests
{
    public class Tests
    {
        private CRUDoperationsForMembers _crudMem;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options = new DbContextOptionsBuilder<TeamFinder3TAppContext>()
                .UseInMemoryDatabase(databaseName: "FakeTeamFinderDb")
                .Options;
            
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}