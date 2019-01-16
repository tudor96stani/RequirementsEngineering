namespace Core.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Offer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Offer()
        {
            Donations = new HashSet<Donation>();
            Participants = new HashSet<AspNetUser>();
        }

        public string Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(128)]
        public string LocationId { get; set; }

        public DateTime? DateTimeUTC { get; set; }

        public double? DonationsGoal { get; set; }

        public int? CandidatesGoal { get; set; }

        [StringLength(128)]
        public string OwnerId { get; set; }

        public virtual AspNetUser Owner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donation> Donations { get; set; }

        public virtual Location Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUser> Participants { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
