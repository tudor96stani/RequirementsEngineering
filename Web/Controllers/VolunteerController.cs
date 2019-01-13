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
    public class VolunteerController : Controller
    {
        private readonly IVolunteerService _volService;
        private readonly IEventService _eventService;
        private readonly ILocationService _locationService;
        private readonly IRatingService _ratingService;

        public VolunteerController()
        {
            _volService = ServiceDependencyResolver.GetVolunteerService();
            _eventService = ServiceDependencyResolver.GetEventService();
            _locationService = ServiceDependencyResolver.GetLocationService();
            _ratingService = ServiceDependencyResolver.GetRatingService();
        }

        //GET /Volunteer/Profile/123456
        public ActionResult Profile(Guid id)
        {
            if (!id.Equals(Guid.Empty))
            {
                var dto = _volService.GetVolunteerProfileDetails(id);
                if (dto != null)
                {
                    var viewModel = new VolunteerProfileViewModel(dto);
                    return View(viewModel);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetEvents(Guid id)
        {
            var events = _volService.GetAllEventsForVolunteer(id);
            var viewModels = events.Select(x => new EventBasicInfoViewModel(x));
            return Json(viewModels, JsonRequestBehavior.AllowGet);
		}


        public ActionResult Index()
        {
            var viewModel = new VolunteerHomepageViewModel();
            viewModel.topOrganizations = GetTopOrganizations();
            viewModel.orderedEvents = GetEvents();
            viewModel.Locations = _locationService.GetAllCities().Select(x => new LocationSelectorViewModel(x)).ToList();
            return View(viewModel);
        }

        public ActionResult Homepage()
        {
            var viewmodel = new VolunteerHomepageViewModel();
            viewmodel.topOrganizations = GetTopOrganizations();
            viewmodel.orderedEvents = GetEvents();

            return View(viewmodel);
        }

        public ActionResult GetEventsByLocation(string location)
        {

            var events = _eventService.GetEventsWithLocation(location);
            var viewModelEvents = events.Select(x => new EventQuickDetailsViewModel(x)).ToList();
            return Json(viewModelEvents, JsonRequestBehavior.AllowGet);
        }
        private List<TopOrganizationViewModel> GetTopOrganizations()
        {
            var topOrganizations = _volService.GetTopOrganizations();
            if (topOrganizations != null)
            {
                var organizationsviewModel = topOrganizations.Select(x => new TopOrganizationViewModel(x)).ToList();
                return organizationsviewModel;
            }
            return new List<TopOrganizationViewModel>();
        }


        private List<EventQuickDetailsViewModel> GetEvents()
        {
            var orderedEvents = _volService.GetAllEvents();
            if (orderedEvents != null)
            {
                var eventsViewModel = orderedEvents.Select(x => new EventQuickDetailsViewModel(x)).ToList();
                return eventsViewModel;
            }
            return new List<EventQuickDetailsViewModel>();
        }

        public JsonResult Rate(string volunteerId, string rating)
        {
            try
            {
                if (rating == "" || Int32.Parse(rating) == 0)
                {
                    return Json(new { Success = "True", Message = "Organization could not be rated" }, JsonRequestBehavior.AllowGet);
                }
                _ratingService.Add(volunteerId, Int32.Parse(rating));
                return Json(new { Success = "True", Message = "Organization successfully rated" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = "False", Message = "Organization could not be rated" }, JsonRequestBehavior.AllowGet);

            }
        }


    }
}