using NUnit.Framework;
using System;

namespace MyPath.Tests.Common
{
    public class EntityCreatorTests<T, R>
    {
        public T InstanceUnderTest { get; set; }

        protected void VerifyPropertyIsSet(Func<R> afterThisMethodCreatesEntity, Func<R, string> thisProperty, string shouldHaveThisValue)
        {
            var entity = afterThisMethodCreatesEntity.Invoke();
            Assert.AreEqual(thisProperty(entity), shouldHaveThisValue);
        }
    }
}