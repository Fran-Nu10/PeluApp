using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Empleado
    {
        public int Id { get; set; } // Identificador único
        public string Nombre { get; set; } // Nombre del empleado
        public string Apellido { get; set; } // Apellido del empleado
        public string Cargo { get; set; } // Cargo del empleado (ej. estilista, recepcionista)
        public string Telefono { get; set; } // Teléfono de contacto
        public decimal Salario { get; set; } // Salario mensual
        public List<Cita> Citas { get; set; } // Relación 1:N con Citas

        // Disponibilidad básica del empleado
        public List<string> DiasDisponibles { get; set; } // Ej. ["Lunes", "Martes", "Viernes"]
        public TimeSpan HoraInicio { get; set; } // Ej. 09:00
        public TimeSpan HoraFin { get; set; } // Ej. 17:00

        public string Rol { get; set; }

        public Empleado()
        {

        }
    }

}
