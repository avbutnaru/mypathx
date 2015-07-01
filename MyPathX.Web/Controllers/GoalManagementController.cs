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
    public class GoalManagementController : MyPathXController
    {
        public GoalManagementController(IBus bus, IMyPathMessageCreator messageCreator): base(bus, messageCreator)
        {
        }

        public ActionResult Add(AddGoalModel model)
        {
            var command = MessageCreator.Create<CreateGoalMessage>();
            command.Name = model.Name;
            command.Description = model.Description;
            Bus.Send("MyPathX.Services.GoalManagement", command);

            return RedirectToAction("index", "home");
        }
    }
}