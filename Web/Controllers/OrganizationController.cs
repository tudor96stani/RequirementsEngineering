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
        private readonly IOfferService _offerService;
        private readonly IRatingService _ratingService;

        public OrganizationController()
        {
            _orgService = ServiceDependencyResolver.GetOrganizationService();
            _offerService = ServiceDependencyResolver.GetOfferService();
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

        public ActionResult GetOffers(Guid id)
        {

            var offers = _orgService.GetAllOffersForOrganization(id);
            var viewModels = offers.Select(x => new OfferBasicInfoViewModel(x));
            return Json(viewModels, JsonRequestBehavior.AllowGet);
            //return Json(null);
        }

        public ActionResult Homepage()
        {
            var viewModel = new OrganizationHomepageViewModel();
            viewModel.topCandidates = GetTopCandidates();
            viewModel.orderedOffers = _orgService.GetAllOffers().Select(x=>new OfferQuickDetailsViewModel(x)).ToList();
            return View(viewModel);
        }

     

        private List<TopCandidateViewModel> GetTopCandidates()
        {
            var topCandidates = _orgService.GetTopCandidates();
            if (topCandidates != null)
            {
                var candidatesviewModel = topCandidates.Select(x => new TopCandidateViewModel(x)).ToList();
                return candidatesviewModel;
            }

            return new List<TopCandidateViewModel>();
        }

        private List<OfferQuickDetailsViewModel> GetOffersOrderedByDate(Guid id)
        {
            var orderedOffers = _orgService.GetAllOffersForOrganizationOrderedByDate(id);
            if (orderedOffers != null)
            {
                var offersviewModel = orderedOffers.Select(x => new OfferQuickDetailsViewModel(x)).ToList();
                return offersviewModel;
            }
            return new List<OfferQuickDetailsViewModel>();
        }

        [HttpPost]
        public ActionResult CreateOffer(CreateOfferViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_offerService.Create(model.OwnerId, model.Name, model.Country, model.City, model.Street, model.Number, model.Date, model.Description, model.CandidatesGoals))
                    {
                        return Json(new { Ok = true, Message = "Ok" }, JsonRequestBehavior.AllowGet);
                    }
                    return Json(new { Ok = false, Message = "Offer could not be created!" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json(new { Ok = false, Message = "Something went wrong" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { Ok=false,Message="Bad request"},JsonRequestBehavior.AllowGet); 
        }

        [HttpPost]
        public ActionResult DeleteOffer(Guid id)
        {
            try
            {
                _offerService.Delete(id);
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
