using Autofac;
using MyPathX.Entities;
using NServiceBus;
using System;

namespace MyPathX.Services.GoalManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new Repository<Goal>()).As<IRepository<Goal>>();
            builder.RegisterInstance(new GoalCreator((IRepository<Goal>)new Repository<Goal>())).As<IGoalCreator>();
            IContainer container = builder.Build();

            BusConfiguration busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("MyPathX.Services.GoalManagement");
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
            busConfiguration.EnableInstallers();

            using (IBus bus = Bus.Create(busConfiguration).Start())
            {
                Console.WriteLine("Doing stuff");
                Console.WriteLine("To exit, press Ctrl + C");

                Console.ReadLine();
            }
        }
    }
}
