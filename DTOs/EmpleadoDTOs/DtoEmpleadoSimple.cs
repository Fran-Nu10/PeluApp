using DTOs.CitaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.EmpleadoDTOs
{
    public class DtoEmpleadoSimple
    {
     
        public string Nombre { get; set; } // Nombre del empleado
        public string Apellido { get; set; } // Apellido del empleado
        public string Cargo { get; set; } // Cargo del empleado (ej. estilista, recepcionista)
        public string Telefono { get; set; } // Teléfono de contacto
        public decimal Salario { get; set; } // Salario mensual

        public TimeSpan HoraInicio { get; set; } // Ej. 09:00
        public TimeSpan HoraFin { get; set; } // Ej. 17:00

        public List<string> DiasDisponibles { get; set; } = new();



        public string? Rol { get; set; }
    }
}
