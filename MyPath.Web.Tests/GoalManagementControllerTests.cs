using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPathX.Messages;
using Moq;
using NServiceBus;
using MyPathX.Web.Controllers;
using MyPathX.Web.Models;
using MyPath.Tests.Common;
using System.Web.Mvc;

namespace MyPathX.Web.Tests
{
    [TestFixture]
    class GoalManagementControllerTests
    {
        private Mock<IBus> _busMock;
        private GoalManagementController _instanceUnderTest;
        private Mock<IMyPathMessageCreator> _messageCreatorMock;

        [SetUp]
        public void Setup()
        {
            _busMock = new Mock<IBus>();
            _messageCreatorMock = new Mock<IMyPathMessageCreator>();
            _instanceUnderTest = new GoalManagementController(_busMock.Object, _messageCreatorMock.Object);
        }

        [Test]
        public void AddSendsMessage()
        {
            var message = new CreateGoalMessage();
            _messageCreatorMock.Setup(p => p.Create<CreateGoalMessage>()).Returns(message);
            var addGoalModel = new AddGoalModel { Name = StringsForTest.RandomString(), Description = StringsForTest.RandomString() };
            _instanceUnderTest.Add(addGoalModel);

            _busMock.Verify(p => p.Send("MyPathX.Services.GoalManagement", message));
        }

        [Test]
        public void AddSetsName()
        {
            var name = StringsForTest.RandomString();
            var message = new CreateGoalMessage();
            _messageCreatorMock.Setup(p => p.Create<CreateGoalMessage>()).Returns(message);
            var addGoalModel = new AddGoalModel { Name = name, Description = StringsForTest.RandomString() };
            _instanceUnderTest.Add(addGoalModel);

            Assert.AreEqual(message.Name, name);
        }

        [Test]
        public void AddSetsDescription()
        {
            var description = StringsForTest.RandomString();
            var message = new CreateGoalMessage();
            _messageCreatorMock.Setup(p => p.Create<CreateGoalMessage>()).Returns(message);
            var addGoalModel = new AddGoalModel { Name = StringsForTest.RandomString(), Description = description };
            _instanceUnderTest.Add(addGoalModel);

            Assert.AreEqual(message.Description, description);
        }

        [Test]
        public void AddRedirectsToHome()
        {
            _messageCreatorMock.Setup(p => p.Create<CreateGoalMessage>()).Returns(new CreateGoalMessage());
            var action = (RedirectToRouteResult)_instanceUnderTest.Add(new AddGoalModel { Name = StringsForTest.RandomString(), Description = StringsForTest.RandomString() });
            Assert.IsAssignableFrom<RedirectToRouteResult>(action);
            Assert.AreEqual("index", action.RouteValues["action"].ToString().ToLower());
            Assert.AreEqual("home", action.RouteValues["controller"].ToString().ToLower());
        }
    }
}
