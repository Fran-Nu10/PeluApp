using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Servicio
    {
        public int Id { get; set; } // Identificador único
        public string Nombre { get; set; } // Nombre del servicio (ej. corte, coloración)
        public string Descripcion { get; set; } // Breve descripción del servicio
        public decimal Precio { get; set; } // Precio del servicio
        public TimeSpan Duracion { get; set; } // Duración aproximada del servicio
        public List<Cliente> Clientes { get; set; } // Relación N:N con Clientes
        public List<Cita> Citas { get; set; } // Relación 1:N con Citas

        public Servicio()
        {

        }

        public Servicio(int id, string nombre, string descripcion, decimal precio, TimeSpan duracion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Duracion = duracion;
        }

    }





}
