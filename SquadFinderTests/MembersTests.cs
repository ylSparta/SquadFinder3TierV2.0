using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using FunctionalityForSquadFinder;
using SquadFinder3Tier.Services;
using SquadFinder3Tier;
using System.Linq;

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

            _crudMem.CreateMember("00001", "Test", "Member");
            _crudMem.CreateMember("00002", "Bob", "Tester");
            _crudMem.CreateMember("00003", "Craig", "Item");
            _crudMem.CreateMember("00004", "Will", "Potter");




        }

        [Test]
        public void TestThatFakeDBHasNoEntries()
        {
            Assert.That(_context.Members.Count(), Is.EqualTo(_crudMem.GetAllMembers().Count));
        }

        [Test]
        public void CheckFakeDBContainsACertainMember()
        {
            Assert.That(_context.Members.Find("00001"), Is.Not.Null);
        }

        [Test]
        public void CheckIfNewMemeberHasBeenAddedToDB()
        {
            //Arrange
            _crudMem.CreateMember("00728","Paul","Merch");
            //Act
            var newMember = (_context.Members.Find("00728"));
            Assert.That(newMember, Is.Not.Null);
            //Assert
            Assert.That(newMember.FirstName, Is.EqualTo("Paul"));
            Assert.That(newMember.LastName, Is.EqualTo("Merch"));

        }

        [Test]
        public void DeleteCreatedMemberInPreviousTest()
        {
            //Arrange
            _crudMem.CreateMember("00728", "Paul", "Merch");
            var newMember = _context.Members.Find("00728");
            Assert.That(newMember.MemberId, Is.EqualTo("00728"));
            //Act
            _crudMem.DeleteMember(newMember);
            //Assert
            Assert.That(_context.Members, Does.Not.Contain(newMember));
        }

    }
}