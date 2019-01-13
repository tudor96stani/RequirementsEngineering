using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DonationDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public Guid EventId { get; set; }
        public double Amount { get; set; }
    }
}
