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
    public class DtoHistorialDeCitas
    {
        public int Id { get; set; } // Identificador único
        public DateTime FechaHora { get; set; } // Fecha y hora de la cita
        public int ClienteId { get; set; } // FK del cliente asociado
        public DtoListarCliente Cliente { get; set; } // Relación con Cliente
        public int EmpleadoId { get; set; } // FK del empleado asignado
        public DtoEmpleado Empleado { get; set; } // Relación con Empleado
        public int ServicioId { get; set; } // FK del servicio seleccionado
        public DtoServicio Servicio { get; set; } // Relación con Servicio
        public string Estado { get; set; } // Estado de la cita (ej. pendiente, completada, cancelada)

        public string NombreServicio { get; set; }

        public DtoHistorialDeCitas(int id, DateTime fechaHora, int clienteId, DtoListarCliente cliente, int empleadoId, DtoEmpleado empleado, int servicioId, DtoServicio servicio, string estado)
        {
            Id = id;
            FechaHora = fechaHora;
            ClienteId = clienteId;
            Cliente = cliente;
            EmpleadoId = empleadoId;
            Empleado = empleado;
            ServicioId = servicioId;
            Servicio = servicio;
            Estado = estado;
        }

        public DtoHistorialDeCitas()
        {
        }
    }
}
