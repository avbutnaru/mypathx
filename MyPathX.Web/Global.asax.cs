using Autofac;
using Autofac.Integration.Mvc;
using MyPathX.Messages;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyPathX.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        IBus bus;

        protected void Application_Start()
        {
            ContainerBuilder builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<MyPathMessageCreator>().As<IMyPathMessageCreator>().InstancePerRequest();

            // Set the dependency resolver to be Autofac.
            IContainer container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            BusConfiguration busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName("MyPathX.Web");
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(container));
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.EnableInstallers();

            var startableBus = Bus.Create(busConfiguration);
            bus = startableBus.Start();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override void Dispose()
        {
            if (bus != null)
            {
                bus.Dispose();
            }
            base.Dispose();
        }
    }
}
