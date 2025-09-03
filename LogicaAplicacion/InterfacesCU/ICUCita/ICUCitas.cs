using DTOs.CitaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.ICUCita
{
    public interface ICUCitas
    {
        List<DtoHistorialDeCitas> HisorialDeCitas();
        List<DtoHistorialDeCitas> HistorialCitasPorCliente(int? id);

        // Métodos CRUD para Cita
        DtoCita GetEditar(int id);
        void PostEditar(DtoCita dto);

        DtoCita GetEliminar(int id);
        void PostEliminar(DtoCita dto);
    }

}
