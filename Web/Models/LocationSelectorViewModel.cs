using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class LocationSelectorViewModel
    {
        
        public string CityName { get; set; }

        public LocationSelectorViewModel(string name)
        {
            CityName = name;
        }
    }
}