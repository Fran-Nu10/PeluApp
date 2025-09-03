using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.Entidades
{
    public class Cliente
    {
        public int Id { get; set; } // Identificador único
        public string Nombre { get; set; } // Nombre del cliente
        public string Apellido { get; set; } // Apellido del cliente
        public int Telefono { get; set; } // Teléfono de contacto
        public string Email { get; set; } // Correo electrónico
        public List<Cita> Citas { get; set; } // Relación 1:N con Citas
        public List<Servicio> Servicios { get; set; } // Relación N:N con Servicios
        public string constrasenia { get; set; }
        public string Rol { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Cliente(int id, string nombre, string apellido, int telefono, string email,
                   string contrasenia, string rol, DateTime fechaCreacion)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Email = email;
            constrasenia     = contrasenia;
            Rol = rol;
            FechaCreacion = fechaCreacion;
            Citas = new List<Cita>();
            Servicios = new List<Servicio>();
        }

        public Cliente()
        {
        }
    }




}
