﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Models
{
    public class Cargo
    {
       public int CargoID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre del cargo debe tener de 3 a 50 caracteres")]
        public string Nombre { get; set; }
    }
}
