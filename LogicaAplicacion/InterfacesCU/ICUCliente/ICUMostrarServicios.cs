using DTOs.CitaDTOs;
using DTOs.ServicioDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.ICUCliente
{
    public interface ICUMostrarServicios
    {
        List<DtoCita> MostrarServiciosPorCliente(int id);
    }
}
