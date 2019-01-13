namespace Core.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Rating
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [Column("Rating")]
        public int? Rating1 { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
