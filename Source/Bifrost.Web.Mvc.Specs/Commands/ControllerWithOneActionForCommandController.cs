﻿using System.Web.Mvc;
using Bifrost.Fakes.Commands;

namespace Bifrost.Web.Mvc.Specs.Commands
{
    public class ControllerWithOneActionForCommandController : Controller
    {
        public ActionResult DoStuff(SimpleCommand command)
        {
            return View();
        }
    }
}
