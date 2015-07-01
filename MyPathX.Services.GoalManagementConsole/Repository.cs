using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPathX.Services.GoalManagement
{
    public class Repository<T> : IRepository<T> where T: class
    {
        public void Add(T entity)
        {
            using (var context = new GoalManagementContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }
    }
}
