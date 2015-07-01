using MyPathX.Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPathX.Services.GoalManagement
{
    public class CreateGoalHandler : IHandleMessages<CreateGoalMessage>
    {
        private IBus _bus;
        private IGoalCreator _goalCreator;

        public CreateGoalHandler(IBus bus, IGoalCreator goalCreator)
        {
            _goalCreator = goalCreator;
            _bus = bus;
        }

        public void Handle(CreateGoalMessage message)
        {
            _goalCreator.Create(message.Name, message.Description);
            _bus.Return(1);
        }
    }
}
