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

            _crudSquad.CreateSquad("0102133", "Anthony Barry", 5, "Football");
            _crudSquad.CreateSquad("3900011", "Frank Lampard", 5, "Football");


        }

        [Test]
        public void TestThatFakeDBHasEntriesAndThatTheyGetRetrieved()
        {
            Assert.That(_context.Squad.Count(), Is.EqualTo(_crudSquad.GetAllSquads().Count));
        }

        [Test]
        public void CheckFakeDBContainsCertainSquad()
        {
            Assert.That(_context.Squad.Find("3900011"), Is.Not.Null);
        }
       

        [Test]
        public void CheckTeamAddedToFakeDB()
        {
            //Arrange
            _crudSquad.CreateSquad("8829302", "Jurgen Klopp", 5, "Football");
            //Act
            var newSquad = _context.Squad.Find("8829302");
            Assert.That(newSquad, Is.Not.Null);
            //Assert
            Assert.That(newSquad.SquadLeader, Is.EqualTo("Jurgen Klopp"));
            Assert.That(newSquad.Sport, Is.EqualTo("Football"));

        }

        [Test]
        public void DeleteCreatedSquadInPreviousTest()
        {
            //Arrange
            _crudSquad.CreateSquad("8829302", "Jurgen Klopp", 5, "Football");
            var newSquad = _context.Squad.Find("8829302");
            Assert.That(newSquad.SquadLeader, Is.EqualTo("Jurgen Klopp"));
            //Act
            _crudSquad.DeleteSquad(newSquad);
            //Assert
            Assert.That(_context.Squad, Does.Not.Contain(newSquad));
        }

        [Test]
        public void NewSquad_NotCreatedIfAlreadyInFakeDB()
        {
            //Arrange
            var firstSquadCount = _context.Squad.Count();
            _crudSquad.CreateSquad("3900011", "Frank Lampard", 5, "Football");
            //Act
            var secondSquadCount = _context.Squad.Count();
            //Assert
            Assert.That(firstSquadCount, Is.EqualTo(secondSquadCount));
        }

        [Test]
        public void Idek6()
        {
            //Arrange
            _crudSquad.UpdateSquad("3900011", "Frank Lampard", 5, "Basketball");
            //Act
            var updatedSquad = _context.Squad.Find("3900011");
            //Assert
            Assert.That(updatedSquad.Sport, Is.EqualTo("Basketball"));
        }

        
    }
}
