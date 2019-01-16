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
        private readonly IOfferService _offerService;

        public HomeController()
        {
            _userService = ServiceDependencyResolver.GetUserService();
            _offerService = ServiceDependencyResolver.GetOfferService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            var offers = _offerService.GetAll();
            
            return View(offers.Select(x=>new OfferQuickDetailsViewModel(x)));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}