using DTOs.CitaDTOs;
using DTOs.ServicioDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.ICUServicio
{
    public interface ICUGestionDeServicios
    {
        List<DtoCita> TodosLosServicios();
        void AgregarServicio(DtoServicio dto)
        void AgregarServicioAPI(DtoServicioAPI dto);


        List<DtoServicio> TodosLosServiciosDtoServicio();

      
            DtoServicio GetEditar(int id);
            void PostEditar(DtoServicio dto);
            DtoServicio GetEliminar(int id);
            void PostEliminar(DtoServicio dto);
        }

   
}
