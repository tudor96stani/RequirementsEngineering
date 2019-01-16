namespace Core.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Donation
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [StringLength(128)]
        public string OfferId { get; set; }

        public double? Amount { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Offer Offer { get; set; }
    }
}
