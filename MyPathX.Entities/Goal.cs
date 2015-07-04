using System;

namespace MyPathX.Entities
{
    public class Goal
    {
        public Goal(string name, string description, string title)
        {
            Name = name;
            Description = description;
            Title = title;
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}