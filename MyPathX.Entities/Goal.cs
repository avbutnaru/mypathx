using System;

namespace MyPathX.Entities
{
    public class Goal
    {
        public Goal(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}