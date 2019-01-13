using Common.Interfaces.Services;
using DependencyResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEventService _eventService;

        public HomeController()
        {
            _userService = ServiceDependencyResolver.GetUserService();
            _eventService = ServiceDependencyResolver.GetEventService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var events = _eventService.GetAll();
            
            return View(events.Select(x=>new EventQuickDetailsViewModel(x)));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}