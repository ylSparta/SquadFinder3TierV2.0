using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using FunctionalityForSquadFinder;
using SquadFinder3Tier.Services;
using SquadFinder3Tier;
using System.Linq;

namespace SquadFinderTests
{
    public class SquadMemberTests
    {
        private TeamFinder3TAppContext _context;
        private CRUDoperationsForSquad _crudSquad;
        private CRUDoperationsForMembers _crudMember;
        private CRUDoperationsForSquadMembers _crudSquadMembers;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options = new DbContextOptionsBuilder<TeamFinder3TAppContext>()
                .UseInMemoryDatabase(databaseName: "FakeTeamFinderDb")
                .Options;
            _context = new TeamFinder3TAppContext(options);
            SquadService squadService = new SquadService(_context);
            _crudSquad = new CRUDoperationsForSquad(squadService);
            MemberService memService = new MemberService(_context);
            _crudMember = new CRUDoperationsForMembers(memService);
            SquadMemberService squaMemService = new SquadMemberService(_context);
            _crudSquadMembers = new CRUDoperationsForSquadMembers(squaMemService);

            _crudSquad.CreateSquad("0102133", "Anthony Barry", 5, "Football");
            _crudSquad.CreateSquad("3900011", "Frank Lampard", 5, "Football");

            _crudMember.CreateMember("03930","Andy","Robertson");
            _crudMember.CreateMember("01002", "Diogo", "Jota");
            _crudMember.CreateMember("29390", "Sadio", "Mane");
            _crudMember.CreateMember("29312", "Mohammed", "Salah");
            _crudMember.CreateMember("29390", "Joel", "Matip");
            _crudMember.CreateMember("28199", "Timo", "Werner");
            _crudMember.CreateMember("77282", "Hakim", "Ziyech");
            _crudMember.CreateMember("00012", "Mason", "Mount");
            _crudMember.CreateMember("00478", "John", "Terry");
            _crudMember.CreateMember("02730", "Kurt", "Zouma");


            _crudSquadMembers.CreateSquadMember("03930", "0102133");
            _crudSquadMembers.CreateSquadMember("01002", "0102133");
            _crudSquadMembers.CreateSquadMember("29390", "0102133");
            _crudSquadMembers.CreateSquadMember("29312", "0102133");
            _crudSquadMembers.CreateSquadMember("29390", "0102133");
            _crudSquadMembers.CreateSquadMember("28199", "3900011");
            _crudSquadMembers.CreateSquadMember("77282", "3900011");
            _crudSquadMembers.CreateSquadMember("00012", "3900011");
            _crudSquadMembers.CreateSquadMember("00478", "3900011");
            

        }

        [Test]
        public void CheckSquadMemberTabelNotEmptyInFakeDB()
        {
            Assert.That(_context.SquadMembers, Is.Not.Null);
        }


        [Test]
        public void CountNumberOfSquadMembersInFakeDB()
        {
            //Arrange
            var squad1Count = _crudSquadMembers.GetAllSquadMembers("0102133").Count;
            var squad2Count = _crudSquadMembers.GetAllSquadMembers("3900011").Count;
            //Act
            var totalSquadCount = squad1Count + squad2Count;
            //Assert
            Assert.That(_context.SquadMembers.Count(),Is.EqualTo(totalSquadCount));
        }


        [Test]
        public void NewSquadMemberIsNotMadeIfTheyAlreadyExistInTable()
        {
            //Arrange
            var firstCount = _crudSquadMembers.GetAllSquadMembers("3900011").Count;
            _crudSquadMembers.CreateSquadMember("00478", "3900011");
            //Act
            var secondCount = _crudSquadMembers.GetAllSquadMembers("3900011").Count;
            //Assert
            Assert.That(firstCount, Is.EqualTo(secondCount));
        }

        [Test]
        public void NewSquadMemberIsMadeIfTheyDoNotExistInTable()
        {
            //Arrange
            var firstCount = _crudSquadMembers.GetAllSquadMembers("3900011").Count;
            _crudSquadMembers.CreateSquadMember("02730", "3900011");
            //Act
            var secondCount = _crudSquadMembers.GetAllSquadMembers("3900011").Count;
            //Assert
            Assert.That(firstCount + 1, Is.EqualTo(secondCount));
        }

    }
}
