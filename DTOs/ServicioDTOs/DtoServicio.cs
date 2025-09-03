using DTOs.CitaDTOs;
using DTOs.ClienteDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ServicioDTOs
{
    public class DtoServicio
    {
        public int Id { get; set; } // Identificador único
        public string Nombre { get; set; } // Nombre del servicio (ej. corte, coloración)
        public string Descripcion { get; set; } // Breve descripción del servicio
        public decimal Precio { get; set; } // Precio del servicio
        public TimeSpan Duracion { get; set; } // Duración aproximada del servicio
        public List<DtoListarCliente> Clientes { get; set; } // Relación N:N con Clientes
        public List<DtoHistorialDeCitas> Citas { get; set; } // Relación 1:N con Citas

        public DtoServicio()
        {

        }

        public DtoServicio(int id,string nom,string des,decimal pre,TimeSpan du)
        {
            Id= id;
            Nombre=nom;
            Descripcion=des;
            Precio=pre;
            Duracion=du;
        }

       
    }
}
