using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Administrador
    {
        public int Id { get; set; } // Identificador único
        public string Usuario { get; set; } // Nombre de usuario
        public string Contraseña { get; set; } // Contraseña para autenticación
        public string Email { get; set; } // Correo electrónico
    }

}
