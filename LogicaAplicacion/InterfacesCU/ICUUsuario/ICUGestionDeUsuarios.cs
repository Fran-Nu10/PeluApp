using DTOs.UsuarioDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.ICUUsuario
{
    public interface ICUGestionDeUsuarios
    {
        DtoUsuario MostrarPerfilDeUsuario(int? IdUsuario);
        DtoUsuario EncontrarUsuario(int? IdUsuario);

    }
}
