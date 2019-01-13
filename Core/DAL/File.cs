namespace Core.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class File
    {
        public string Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [StringLength(100)]
        public string OriginalName { get; set; }

        [StringLength(10)]
        public string Extension { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
