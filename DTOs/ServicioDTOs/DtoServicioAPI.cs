using DTOs.CitaDTOs;
using DTOs.ClienteDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ServicioDTOs
{
    public class DtoServicioAPI
    {
        public string Nombre { get; set; } // Nombre del servicio (ej. corte, coloración)
        public string Descripcion { get; set; } // Breve descripción del servicio
        public decimal Precio { get; set; } // Precio del servicio
        public TimeSpan Duracion { get; set; } // Duración aproximada del servicio
        public List<DtoListarCliente> Clientes { get; set; } // Relación N:N con Clientes
        public List<DtoHistorialDeCitas> Citas { get; set; } // Relación 1:N con Citas

        public DtoServicioAPI() { } //QUEDE EN PORQUE EL DTO SERVICIO NO VAN LISTAS 
    }
}
