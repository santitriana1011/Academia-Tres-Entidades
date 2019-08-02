using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public int CargoID { get; set; }
        public Cargo Cargo { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "El Nombre del empleado debe tener de 3 a 10 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "El Apellido del empleado debe tener de 3 a 10 caracteres")]
        public string Apellido { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "El numero de documento debe tener de 3 a 10 caracteres")]
        public string Documento { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "El numero telefonico debe tener de 3 a 10 caracteres")]
        public string Telefono { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 5, ErrorMessage = "La direccion del empleado debe tener minimo 5 caracteres")]
        public string Direccion { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 3, ErrorMessage = "El su contraseña debe tener de 3 a 8 caracteres")]
        public string Contrasenia { get; set; }
        public string Rol { get; set; }


    }
}
