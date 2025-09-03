using DTOs.CitaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.ICUCita
{
    public interface ICUAgendarCitas
    {

        void AgendarCita(DtoCita dtoCita, int? id,int EmpleadoId,int ServiciosId);
    }
}
