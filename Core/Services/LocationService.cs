
﻿using Common.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using Core.DAL;
using Core.Utils;

namespace Core.Services
{
    public class LocationService : Common.Interfaces.Services.ILocationService
    {
        public List<LocationDTO> GetAll()
        {
            using (var dbContext = new ApplicationDbContext())
            {

                List<LocationDTO> locations = dbContext.Locations.AsEnumerable().Select(x => x.ToDTO()).ToList();
                return locations;
            }
        }
        public List<string> GetAllCities()
        {
            using (var dbCtx = new ApplicationDbContext())
            {
                var locations = dbCtx.Locations.Select(x => x.City).Distinct().ToList();
                return locations;
            }
        }
    }
}