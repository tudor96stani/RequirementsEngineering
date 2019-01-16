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
    public class OfferController : Controller
    {
        private static IOfferService _offerService;
        private static IUserService _userService;
        private static ILocationService _locationService;

        public OfferController()
        {
            _offerService = ServiceDependencyResolver.GetOfferService();
            _userService = ServiceDependencyResolver.GetUserService();
            _locationService = ServiceDependencyResolver.GetLocationService();
        }

        // GET: Offer
        public ActionResult Index(Guid id)
        {
            
            OfferProfileViewModel offerViewModel = new OfferProfileViewModel(_offerService.GetDto(id));
            return View(offerViewModel);
        }

        public ActionResult EditPage(Guid offerId)
        {
            var locationList = getLocations();

            OfferEditViewModel offerViewModel = new OfferEditViewModel(_offerService.GetDto(offerId),locationList);
            
            return View(offerViewModel);
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
        public ActionResult Edit(OfferEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid id = model.Id;
                _offerService.UpdateOffer(model.Name, model.DateTimeUtc, model.Description, model.LocationId, model.Id);

                return RedirectToAction("Index", new { id });
            }
            var locationList = getLocations();
            model.LocationList = locationList;
            return View("EditPage",model);
        }

       
        [HttpPost]
        public ActionResult AddParticipant(string offerId)
        {
                _offerService.AddParticipant(offerId, User.Identity.GetUserId());
                List<UserBasicViewModel> basicUsers = _offerService.GetDto(Guid.Parse(offerId))
                    .Participants.Select(x => new UserBasicViewModel(x)).ToList();
                CandidateListViewModel candidatesListViewModel = new CandidateListViewModel( Guid.Parse(offerId),
                    basicUsers);
                return PartialView("CandidatesPartial", candidatesListViewModel);
        }
    }
}