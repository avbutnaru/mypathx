using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPathX.Messages
{
    public interface IMyPathMessageCreator
    {
        T Create<T>() where T : new();
    }

    public class MyPathMessageCreator : IMyPathMessageCreator
    {
        public T Create<T>() where T : new()
        {
            return new T();
        }
    }
}
