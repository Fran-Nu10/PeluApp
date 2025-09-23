using DTOs.CitaDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.EmpleadoDTOs
{
    public class DtoEmpleado
    {
        public int Id { get; set; } // Identificador único
        public string Nombre { get; set; } // Nombre del empleado
        public string Apellido { get; set; } // Apellido del empleado
        public string Cargo { get; set; } // Cargo del empleado (ej. estilista, recepcionista)
        public string Telefono { get; set; } // Teléfono de contacto
        public decimal Salario { get; set; } // Salario mensual
        public List<DtoCita> Citas { get; set; } // Relación 1:N con Citas

        public string Rol { get; set; }


        public DtoEmpleado() { }

        public DtoEmpleado(string nombre, string apellido, string cargo, string telefono, decimal salario)
        {
            
            Nombre = nombre;
            Apellido = apellido;
            Cargo = cargo;
            Telefono = telefono;
            Salario = salario;
        }
    }
}
