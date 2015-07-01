using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPathX.Entities;
using MyPathX.Messages;
using Moq;
using NServiceBus;
using MyPath.Tests.Common;
using NServiceBus.Testing;

namespace MyPathX.Services.GoalManagement.Tests
{
    [TestFixture]
    class CreateGoalHandlerTests
    {
        [Test]
        public void CreatesGoal()
        {
            var name = StringsForTest.RandomString();
            var description = StringsForTest.RandomString();
            var entity = new Goal(StringsForTest.RandomString(), StringsForTest.RandomString());

            var goalCreator = new Mock<IGoalCreator>();
            var bus = new Mock<IBus>();
            var sut = new CreateGoalHandler(bus.Object, goalCreator.Object);

            sut.Handle(new CreateGoalMessage { Name = name, Description = description });

            goalCreator.Verify(p => p.Create(name, description));
        }

        [Test]
        public void ReturnsSuccess()
        {
            var goalCreator = new Mock<IGoalCreator>();
            var bus = new Mock<IBus>();
            var sut = new CreateGoalHandler(bus.Object, goalCreator.Object);

            sut.Handle(new CreateGoalMessage { Name = StringsForTest.RandomString(), Description = StringsForTest.RandomString() });

            bus.Verify(p => p.Return(1));
        }
    }
}
