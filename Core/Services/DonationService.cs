using System;
using Common.DTO;
using Common.Interfaces.Services;
using Core.DAL;
using Core.Utils;

namespace Core.Services
{
    public class DonationService :IDonationService
    {
        public void Add(string userId, string offerId, double amount)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                Donation da = new Donation()
                {
                    UserId = userId,
                    OfferId = offerId,
                    Amount = amount
                };
                _dbContext.Donations.Add(da);
                _dbContext.SaveChanges();
            }

        }

    }
}