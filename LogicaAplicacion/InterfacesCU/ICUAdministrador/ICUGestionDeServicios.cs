using DTOs.ServicioDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.ICUAdministrador
{
    public interface ICUGestionDeServicios
    {
        void  AgregarServicio(DtoServicio dto);
    }
}
