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
    public class CandidateController : Controller
    {
        private readonly ICandidateService _volService;
        private readonly IOfferService _offerService;
        private readonly ILocationService _locationService;
        private readonly IRatingService _ratingService;

        public CandidateController()
        {
            _volService = ServiceDependencyResolver.GetCandidateService();
            _offerService = ServiceDependencyResolver.GetOfferService();
            _locationService = ServiceDependencyResolver.GetLocationService();
            _ratingService = ServiceDependencyResolver.GetRatingService();
        }

        //GET /Candidate/Profile/123456
        public ActionResult Profile(Guid id)
        {
            if (!id.Equals(Guid.Empty))
            {
                var dto = _volService.GetCandidateProfileDetails(id);
                if (dto != null)
                {
                    var viewModel = new CandidateProfileViewModel(dto);
                    return View(viewModel);
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult GetOffers(Guid id)
        {
            var offers = _volService.GetAllOffersForCandidate(id);
            var viewModels = offers.Select(x => new OfferBasicInfoViewModel(x));
            return Json(viewModels, JsonRequestBehavior.AllowGet);
		}


        public ActionResult Index()
        {
            var viewModel = new CandidateHomepageViewModel();
            viewModel.topOrganizations = GetTopOrganizations();
            viewModel.orderedOffers = GetOffers();
            viewModel.Locations = _locationService.GetAllCities().Select(x => new LocationSelectorViewModel(x)).ToList();
            return View(viewModel);
        }

        public ActionResult Homepage()
        {
            var viewmodel = new CandidateHomepageViewModel();
            viewmodel.topOrganizations = GetTopOrganizations();
            viewmodel.orderedOffers = GetOffers();

            return View(viewmodel);
        }

        public ActionResult GetOffersByLocation(string location)
        {

            var offers = _offerService.GetOffersWithLocation(location);
            var viewModelOffers = offers.Select(x => new OfferQuickDetailsViewModel(x)).ToList();
            return Json(viewModelOffers, JsonRequestBehavior.AllowGet);
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


        private List<OfferQuickDetailsViewModel> GetOffers()
        {
            var orderedOffers = _volService.GetAllOffers();
            if (orderedOffers != null)
            {
                var offersViewModel = orderedOffers.Select(x => new OfferQuickDetailsViewModel(x)).ToList();
                return offersViewModel;
            }
            return new List<OfferQuickDetailsViewModel>();
        }

        public JsonResult Rate(string candidateId, string rating)
        {
            try
            {
                if (rating == "" || Int32.Parse(rating) == 0)
                {
                    return Json(new { Success = "True", Message = "Organization could not be rated" }, JsonRequestBehavior.AllowGet);
                }
                _ratingService.Add(candidateId, Int32.Parse(rating));
                return Json(new { Success = "True", Message = "Organization successfully rated" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { Success = "False", Message = "Organization could not be rated" }, JsonRequestBehavior.AllowGet);

            }
        }


    }
}