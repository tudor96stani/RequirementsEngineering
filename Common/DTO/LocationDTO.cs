using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class LocationDTO
    {
        public string Id { get; set; }

       
        public string Country { get; set; }

      
        public string City { get; set; }

        public string Street { get; set; }

        public int? Number { get; set; }
    }
}
