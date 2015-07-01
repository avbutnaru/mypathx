using MyPathX.Entities;

namespace MyPathX.Services.GoalManagement
{
    public interface IRepository<T>
    {
        void Add(T entity);
    }
}