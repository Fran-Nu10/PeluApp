using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioCliente:IRepositorio<Cliente>
    {
        int FindByIdUsuActual(Usuario usuario);
        Cliente FindByEmail(string email);

        int FindByEmailParaId(string email);
    }
}
