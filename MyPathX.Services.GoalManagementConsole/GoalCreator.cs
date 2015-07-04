using MyPathX.Entities;
using System;

namespace MyPathX.Services.GoalManagement
{
    public class GoalCreator: IGoalCreator
    {
        private IRepository<Goal> _repository;

        public GoalCreator(IRepository<Goal> repository)
        {
            _repository = repository;
        }

        public Goal Create(string name, string description, string title)
        {
            var entity = new Goal(name, description, title);

            _repository.Add(entity);

            return entity;
        }
    }

    public interface IGoalCreator
    {
        Goal Create(string name, string description, string title);
    }
}