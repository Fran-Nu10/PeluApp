using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ClienteDTOs
{

    /// <summary>
    ///DTO VIEJO YA QUE USA LISTAS AL CREAR CLIENTE QUE VAN VACIAS
    /// </summary>
    public class DtoNuevoCliente
    {
        public int Id { get; set; } 
        public string Nombre { get; set; } 
        public string Apellido { get; set; } 
        public int Telefono { get; set; } 
        public string Email { get; set; } 
        public List<Cita> Citas { get; set; } // CREAR DTO PARA ESTA LISTA
        public List<Servicio> Servicios { get; set; } //  CREAR DTO PARA ESTA LISTA
        public string constrasenia { get; set; }
        public string Rol { get; set; }
        public DateTime FechaCreacion { get; set; }

        public DtoNuevoCliente() { }

        public DtoNuevoCliente(int id,string nombre, string apellido, int telefono, string email, string contrasenia, DateTime fechaCreacion)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Email = email;
            contrasenia = contrasenia;
            FechaCreacion = fechaCreacion;
        }
    }
}
