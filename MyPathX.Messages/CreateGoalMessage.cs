using NServiceBus;

namespace MyPathX.Messages
{
    public class CreateGoalMessage : ICommand
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
    }
}