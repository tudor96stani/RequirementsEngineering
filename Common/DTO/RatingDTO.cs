﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public Guid UserId { get; set; }
    }
}
