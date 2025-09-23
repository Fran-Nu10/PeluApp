using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios.InterfacesMVC
{
    public interface IRepositorioEmpleado : IRepositorio<Empleado>
    {
        List<DateTime> DevolverHorariosOcupados(Empleado e, List<DateTime> horariosPosibles);
        List<DateTime> DevolverHorariosLibres(List<DateTime> horariosOcupados, List<DateTime> horariosPosibles);
        Empleado FindByIdEmpleado(int id);
    }
}
