    using DTOs.EmpleadoDTOs;
    using LogicaNegocio.Entidades;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace LogicaAplicacion.InterfacesCU.ICUEmpleado
    {
        public interface ICUGestionDeEmpleados
        {
            List<DtoEmpleado> TodosLosEmpleados();
        DtoEmpleado EncontrarEmpleado(int id);
        DtoEmpleado EncontrarEmpleadoSimple(int id);
        List<DateTime> ObtenerHorariosDisponibles(DtoEmpleado empleado, DateTime fecha);

            void RegistrarEmpleado(DtoEmpleado dto);
        void RegistrarEmpleadoSimple(DtoEmpleadoSimple dto);
        void AcutualizarEmpleado(int id,DtoEmpleadoSimple dto);
    }
}
