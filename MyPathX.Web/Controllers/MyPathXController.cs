using MyPathX.Messages;
using MyPathX.Web.Models;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPathX.Web.Controllers
{
    public class MyPathXController : Controller
    {
        protected IBus Bus;
        protected IMyPathMessageCreator MessageCreator;

        public MyPathXController(IBus bus, IMyPathMessageCreator messageCreator)
        {
            Bus = bus;
            MessageCreator = messageCreator;
        }
    }
}