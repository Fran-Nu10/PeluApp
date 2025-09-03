using DTOs.UsuarioDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.ICUUsuario
{
    public interface ICULogin
    {
        public DtoLogin Login(DtoLogin Login);

    }
}
