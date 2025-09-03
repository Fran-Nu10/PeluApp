using DTOs.UsuarioDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.ICUCliente
{
    public interface ICURegistrarCliente
    {
        public void RegistroCliente(DtoRegistroUsuario Cli);
    }
}
