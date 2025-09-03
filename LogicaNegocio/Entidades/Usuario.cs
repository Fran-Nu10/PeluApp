using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; } // Identificador único del usuario
        public string Nombre { get; set; } // Nombre del usuario
        public string Apellido { get; set; } // Apellido del usuario
        public string Email { get; set; } // Correo electrónico del usuario
        public string Contrasena { get; set; } // Contraseña del usuario
        public string Telefono { get; set; } // Teléfono del usuario
        public string Rol { get; set; } // Rol del usuario (puede ser un enum o una clase relacionada)
        public DateTime FechaRegistro { get; set; } // Fecha de registro del usuario
        public bool Activo { get; set; } // Indica si el usuario está activo o no

        public Usuario()
        {

        }
        public Usuario(int id, string nombre, string apellido, string email, string contrasena, string telefono, string rol, DateTime fechaRegistro, bool activo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Contrasena = contrasena;
            Telefono = telefono;
            Rol = rol;
            FechaRegistro = fechaRegistro;
            Activo = activo;
        }
    }
}
