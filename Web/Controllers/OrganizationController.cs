using Common.Interfaces.Services;
using DependencyResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Web.Models;

namespace Web.Controllers
{
    //[Authorize]
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService _orgService;
        private readonly IEventService _eventService;
        private readonly IRatingService _ratingService;

        public OrganizationController()
        {
            _orgService = ServiceDependencyResolver.GetOrganizationService();
            _eventService = ServiceDependencyResolver.GetEventService();
            _ratingService = ServiceDependencyResolver.GetRatingService();
        }

        //GET /Organization/Profile/123456
        public ActionResult Profile(Guid id)
        {
            if (!id.Equals(Guid.Empty))
            {
                var dto = _orgService.GetOrganizationProfileDetails(id);
                if (dto != null)
                {
                    //var viewModel = new OrganizationProfileVgiiewModel(dto);
                    //return View(viewModel);
                    var viewModel = new OrganizationProfileViewModel(dto);
                    return View(viewModel);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetEvents(Guid id)
        {

            var events = _orgService.GetAllEventsForOrganization(id);
            var viewModels = events.Select(x => new EventBasicInfoViewModel(x));
            return Json(viewModels, JsonRequestBehavior.AllowGet);
            //return Json(null);
        }

        public ActionResult Homepage()
        {
            var viewModel = new OrganizationHomepageViewModel();
            viewModel.topVolunteers = GetTopVolunteers();
            viewModel.orderedEvents = _orgService.GetAllEvents().Select(x=>new EventQuickDetailsViewModel(x)).ToList();
            return View(viewModel);
        }

     

        private List<TopVolunteerViewModel> GetTopVolunteers()
        {
            var topVolunteers = _orgService.GetTopVolunteers();
            if (topVolunteers != null)
            {
                var volunteersviewModel = topVolunteers.Select(x => new TopVolunteerViewModel(x)).ToList();
                return volunteersviewModel;
            }

            return new List<TopVolunteerViewModel>();
        }

        private List<EventQuickDetailsViewModel> GetEventsOrderedByDate(Guid id)
        {
            var orderedEvents = _orgService.GetAllEventsForOrganizationOrderedByDate(id);
            if (orderedEvents != null)
            {
                var eventsviewModel = orderedEvents.Select(x => new EventQuickDetailsViewModel(x)).ToList();
                return eventsviewModel;
            }
            return new List<EventQuickDetailsViewModel>();
        }

        [HttpPost]
        public ActionResult CreateEvent(CreateEventViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_eventService.Create(model.OwnerId, model.Name, model.Country, model.City, model.Street, model.Number, model.Date, model.Description, model.VolunteersGoals, model.DonationsGoal))
                    {
                        return Json(new { Ok = true, Message = "Ok" }, JsonRequestBehavior.AllowGet);
                    }
                    return Json(new { Ok = false, Message = "Event could not be created!" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(new { Ok = false, Message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { Ok=false,Message="Bad request"},JsonRequestBehavior.AllowGet); 
        }

        [HttpPost]
        public ActionResult DeleteEvent(Guid id)
        {
            try
            {
                _eventService.Delete(id);
                return Json(new { Ok = true, Message = "Ok" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { Ok = false, Message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult Rate(string organizationId, string rating)
        {
            try
            {
                if (rating == "" || Int32.Parse(rating) == 0)
                {
                    return Json(new { Success = "True", Message = "Organization could not be rated" }, JsonRequestBehavior.AllowGet);
                }
                _ratingService.Add( organizationId, Int32.Parse(rating));
                return Json(new { Success = "True", Message = "Organization successfully rated" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = "False", Message = "Organization could not be rated" }, JsonRequestBehavior.AllowGet);

            }
        }

    }
}
