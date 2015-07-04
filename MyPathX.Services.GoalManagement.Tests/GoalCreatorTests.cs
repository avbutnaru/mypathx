using Moq;
using MyPath.Tests.Common;
using MyPathX.Entities;
using NUnit.Framework;

namespace MyPathX.Services.GoalManagement.Tests
{
    [TestFixture]
    class GoalCreatorTests: EntityCreatorTests<GoalCreator, Goal>
    {
        private Mock<IRepository<Goal>> _repositoryMock;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository<Goal>>();
            InstanceUnderTest = new GoalCreator(_repositoryMock.Object);
        }

        [Test]
        public void CreateSetsName()
        {
            VerifyPropertyIsSet(() => InstanceUnderTest.Create(StringsForTest.FixedString(), StringsForTest.RandomString(), StringsForTest.RandomString()), p => p.Name, StringsForTest.FixedString());
        }

        [Test]
        public void CreateSetsDescription()
        {
            VerifyPropertyIsSet(() => InstanceUnderTest.Create(StringsForTest.RandomString(), StringsForTest.FixedString(), StringsForTest.RandomString()), p => p.Description, StringsForTest.FixedString());
        }

        [Test]
        public void CreateSetsTitle()
        {
            VerifyPropertyIsSet(() => InstanceUnderTest.Create(StringsForTest.RandomString(), StringsForTest.RandomString(), StringsForTest.FixedString()), p => p.Title, StringsForTest.FixedString());
        }

        [Test]
        public void CreatePersistsEntity()
        {
            var entity = InstanceUnderTest.Create(StringsForTest.RandomString(), StringsForTest.RandomString(), StringsForTest.RandomString());
            _repositoryMock.Verify(p => p.Add(entity));
        }
    }
}
