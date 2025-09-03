using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.ClienteDTOs
{
    public class DtoListarCliente
    {
      
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string constrasenia { get; set; }
        public DateTime FechaCreacion { get; set; }

        public DtoListarCliente(string nombre, string apellido, int telefono, string email, string Constrasenia, DateTime fechaCreacion)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Email = email;
           constrasenia = Constrasenia;
            FechaCreacion = fechaCreacion;
        }
        public DtoListarCliente() { }

    }
}
