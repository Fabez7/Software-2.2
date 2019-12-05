using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public class Empleado:EntidadBase
    {
        public int Id_Empleado { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se debe ingresar Dígitos")]
        [StringLength(8, ErrorMessage = "Debes Ingresar 8 Dígitos", MinimumLength = 8)]
        public String DNI { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String GradoAcademico { get; set; }

        [RegularExpression("^[A-Z a-z ñÑáéíóúÁÉÍÓÚ]*$", ErrorMessage = "Solo se debe ingresar letras")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public String Nombre { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se debe ingresar Dígitos")]
        public String Telefono { get; set; }
        public String EstadoCivil { get; set; }
        public String Direccion { get; set; }

    }
}
