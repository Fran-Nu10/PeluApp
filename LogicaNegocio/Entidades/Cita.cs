using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Cita
    {
        public int Id { get; set; } // Identificador único
        public DateTime FechaHora { get; set; } // Fecha y hora de la cita
        public int ClienteId { get; set; } // FK del cliente asociado
        public Cliente Cliente { get; set; } // Relación con Cliente
        public int EmpleadoId { get; set; } // FK del empleado asignado
        public Empleado Empleado { get; set; } // Relación con Empleado
        public int ServicioId { get; set; } // FK del servicio seleccionado
        public Servicio Servicio { get; set; } // Relación con Servicio
        public string Estado { get; set; } // Estado de la cita (ej. pendiente, completada, cancelada)

         // Constructor simple
    public Cita(int id, DateTime fechaHora, int clienteId, Cliente cliente,
                int empleadoId, Empleado empleado, int servicioId, Servicio servicio, string estado)
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

        public Cita()
        {

        }
    }



   
    }


    


