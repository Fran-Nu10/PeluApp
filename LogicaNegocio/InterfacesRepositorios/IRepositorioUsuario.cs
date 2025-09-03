
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario:IRepositorio<Usuario>
    {
        Usuario BuscarPorMail(string email,string pasw);
        Usuario FindByIdPerfil(int? idUsuario);

        Usuario FindByIdUsuario(int? id);
        Usuario FindByIdUsu(int? id);

    }
}
