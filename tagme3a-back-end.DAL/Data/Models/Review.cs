﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tagme3a_back_end.DAL.Data.Models
{
    public class Review
    {
        public int ProductId { get; set; }

        public virtual Product? Product { get; set; }

        [MaxLength(450)]
        public string UserId { get; set; } = string.Empty;
        public virtual User? User { get; set; }

        public string ReviewTitle = string.Empty;

        public string ReviewBody = string.Empty;
        [Range(0,5)]
        public int Rate { get; set; }
    }
}
