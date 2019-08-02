using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Models
{
    public class Hojadevida
    {
        public int HojadevidaID { get; set; }
        public int EmpleadoID { get; set; }
        public Empleado Empleado { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El nombre de la especialidad debe tener de 3 a 20 caracteres")]
        public string Especialidad { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El tiempo de experiencia debe tener de 3 a 20 caracteres")]
        public string TiempoExperiencia { get; set; }

    }
}
