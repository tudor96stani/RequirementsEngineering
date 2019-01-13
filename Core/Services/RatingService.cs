using Common.Interfaces.Services;
using Core.DAL;

namespace Core.Services
{
    public class RatingService : IRatingService
    {
        public void Add(string userId, int rating)
        {
            using (var _dbContext = new ApplicationDbContext())
            {
                Rating da = new Rating()
                {
                    UserId = userId,
                    Rating1 = rating
                };
                _dbContext.Ratings.Add(da);
                _dbContext.SaveChanges();
            }

        }
    }
}