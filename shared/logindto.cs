﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shared.identitydtos
{
    public class logindto
    {
        [EmailAddress]
        [Required]
        public string email { get; set; }
        [Required]

        public string password { get; set; } 
    }
}
