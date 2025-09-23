using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios.InterfacesMVC
{
    public interface IRepositorioCita : IRepositorio<Cita>
    {

        List<Cita> FindByIdLista(int? id);
        List<Cita> MostrarServiciosClientes(int? id);
    }
}
