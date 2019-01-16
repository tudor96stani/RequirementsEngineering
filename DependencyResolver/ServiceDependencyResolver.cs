using Common.Interfaces.Services;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyResolver
{
    public static class ServiceDependencyResolver
    {
        private static Lazy<IUserService> UserService = new Lazy<IUserService>(() => new UserService());
        public static IUserService GetUserService()
        {
            return UserService.Value;
        }

        private static Lazy<IOfferService> OfferService = new Lazy<IOfferService>(() => new OfferService());
        public static IOfferService GetOfferService()
        {
            return OfferService.Value;
        }

       
        private static Lazy<IOrganizationService> OrganizationService = new Lazy<IOrganizationService>(() => new OrganizationService());
        public static IOrganizationService GetOrganizationService()
        {
            return OrganizationService.Value;
        }
        private static Lazy<ICandidateService> CandidateService = new Lazy<ICandidateService>(() => new CandidateService());
        public static ICandidateService GetCandidateService()
        {
            return CandidateService.Value;
        }

        private static Lazy<ILocationService> LocationService = new Lazy<ILocationService>(() => new LocationService());
        public static ILocationService GetLocationService()
        {
            return LocationService.Value;
        }

        private static Lazy<IRatingService> RatingService = new Lazy<IRatingService>(() => new RatingService());
        public static IRatingService GetRatingService()
        {
            return RatingService.Value;
        }




    }
}
