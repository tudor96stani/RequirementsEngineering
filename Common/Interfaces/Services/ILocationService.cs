
﻿using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Services
{
    public interface ILocationService
    {
       List<LocationDTO> GetAll();
        List<string> GetAllCities();
    }
}
