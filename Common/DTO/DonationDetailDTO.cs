using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DonationDetailDTO
    {
        public UserDTO Donor { get; set; }
        public double Amount { get; set; }

        public DonationDetailDTO()
        {

        }

        public DonationDetailDTO(UserDTO donor,double amount)
        {
            Donor = donor;
            Amount = amount;
        }
    }
}
