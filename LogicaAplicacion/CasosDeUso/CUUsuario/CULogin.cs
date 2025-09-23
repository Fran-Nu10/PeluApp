using DTOs;
using DTOs.UsuarioDTOs;
using LogicaAplicacion.InterfacesCU.ICUUsuario;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios.InterfacesMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUUsuario
{
    public class CULogin : ICULogin
    {
        private IRepositorioUsuario _RepoUsu;

        public CULogin(IRepositorioUsuario repositorioUsuario)
        {
            _RepoUsu = repositorioUsuario;
        }

        public DtoLogin Login(DtoLogin Login)
        {
            Usuario UsuarioBuscado=_RepoUsu.BuscarPorMail(Login.Email,Login.Contrasena);
            if (UsuarioBuscado is not null)
            {
                if (UsuarioBuscado.Contrasena == Login.Contrasena)
                {
                    DtoLogin dtoret = MapperUsuario.DeUsuarioLoginaDtoLogin(UsuarioBuscado);

                    return dtoret;
                }
                else
                {
                    throw new Exception("Password NO valido");
                }
            }
            else
            {
                throw new Exception("Email NO Valido");
            }
        }
    }
}
