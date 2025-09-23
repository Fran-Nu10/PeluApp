using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios.InterfacesMVC
{
    public interface IRepositorioServicio : IRepositorio<Servicio>
    {
        List<Servicio> FindByIdList(List<int> Serv);
    }
}
