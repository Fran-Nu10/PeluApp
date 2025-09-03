using DTOs.ClienteDTOs;
using DTOs.EmpleadoDTOs;
using DTOs.ServicioDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.CitaDTOs
{
    public class DtoCita
    {
        private Servicio servicio;
        private string nombre;
        private decimal precio;
        private string descripcion;

        public int Id { get; set; } // Identificador único
        public DateTime FechaHora { get; set; } // Fecha y hora de la cita
        public int ClienteId { get; set; } // FK del cliente asociado
        public DtoNuevoCliente Cliente { get; set; } // Relación con Cliente
        public int EmpleadoId { get; set; } // FK del empleado asignado
        public DtoEmpleado empleado { get; set; } // Relación con Empleado
        public int ServicioId { get; set; } // FK del servicio seleccionado
        public Servicio Servicio { get; set; } // FK del servicio seleccionado
        public List<DtoServicio >Servicios{ get; set; } // Relación con Servicio
        public string Estado { get; set; } // Estado de la cita (ej. pendiente, completada, cancelada)
        public string NombreServicio { get; set; } // Estado de la cita (ej. pendiente, completada, cancelada)


        public string Descripcion { get; set; }
        public decimal Precio { get; set; }


        public DtoCita()
        {

        }

        public DtoCita( int id,string nmbreServicio )
        {
            Id=id;
            NombreServicio = nmbreServicio;
        }

       

        public DtoCita(Servicio servicio, string nombre, decimal precio, string descripcion)
        {
            this.servicio = servicio;
            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
        }
    }
}
