using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.DTO;
using Common.Interfaces.Services;
using DependencyResolver;
using Microsoft.AspNet.Identity;
using Web.Models;

namespace Web.Controllers
{
    public class EventController : Controller
    {
        private static IEventService _eventService;
        private static IUserService _userService;
        private static IDonationService _donationService;
        private static ILocationService _locationService;

        public EventController()
        {
            _eventService = ServiceDependencyResolver.GetEventService();
            _userService = ServiceDependencyResolver.GetUserService();
            _donationService = ServiceDependencyResolver.GetDonationService();
            _locationService = ServiceDependencyResolver.GetLocationService();
        }

        // GET: Event
        public ActionResult Index(Guid id)
        {
            
            EventProfileViewModel eventViewModel = new EventProfileViewModel(_eventService.GetDto(id));
            return View(eventViewModel);
        }

        public ActionResult EditPage(Guid eventId)
        {
            var locationList = getLocations();

            EventEditViewModel eventViewModel = new EventEditViewModel(_eventService.GetDto(eventId),locationList);
            
            return View(eventViewModel);
        }


        private List<SelectListItem> getLocations()
        {
            var locations = _locationService.GetAll();

            List<SelectListItem> locationList = new List<SelectListItem>();
            foreach (LocationDTO location in locations)
            {
                locationList.Add(
                    new SelectListItem()
                    {
                        Value = location.Id,
                        Text = location.Country + ", " + location.City + ", " + location.Street + ", " + location.Number
                    }
                );
            }
            return locationList;
        }



        [HttpPost]
        public ActionResult Edit(EventEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid id = model.Id;
                _eventService.UpdateEvent(model.Name, model.DateTimeUtc, model.Description, model.LocationId, model.Id);

                return RedirectToAction("Index", new { id });
            }
            var locationList = getLocations();
            model.LocationList = locationList;
            return View("EditPage",model);
        }

        [HttpPost]
        public JsonResult AddDonation(string eventId, string amount)
        {
            try
            {
                if (amount == "" || Double.Parse(amount) == 0)
                {
                  return Json(new { Success = "True", Message = "Donation could not be added" }, JsonRequestBehavior.AllowGet);
                }
                _donationService.Add(User.Identity.GetUserId(), eventId,Double.Parse(amount));
                return Json(new { Success = "True", Message="Donation added with success" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { Success = "False", Message = "Donation could not be added" }, JsonRequestBehavior.AllowGet);

            }
        }

        [HttpPost]
        public ActionResult AddParticipant(string eventId)
        {
                _eventService.AddParticipant(eventId, User.Identity.GetUserId());
                List<UserBasicViewModel> basicUsers = _eventService.GetDto(Guid.Parse(eventId))
                    .Participants.Select(x => new UserBasicViewModel(x)).ToList();
                VolunteersListViewModel volunteersListViewModel = new VolunteersListViewModel( Guid.Parse(eventId),
                    basicUsers);
                return PartialView("VolunteersPartial", volunteersListViewModel);
        }
    }
}