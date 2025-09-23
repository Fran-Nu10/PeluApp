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
    public class CUGestionDeUsuarios: ICUGestionDeUsuarios
    {
        private IRepositorioUsuario _RepoUsu;


        public CUGestionDeUsuarios(IRepositorioUsuario repositorio)
        {
            _RepoUsu = repositorio;
        }

        public DtoUsuario MostrarPerfilDeUsuario(int? IdUsuario)
        {
            Usuario usu=_RepoUsu.FindByIdPerfil(IdUsuario);

            DtoUsuario Usuarios = MapperUsuario.DeUsuarioADtoCli(usu);

            return Usuarios;
        }

        public DtoUsuario EncontrarUsuario(int? IdUsuario)
        {
            Usuario usu = _RepoUsu.FindByIdUsuario(IdUsuario);


            DtoUsuario Usuarios = MapperUsuario.DeUsuarioADtoCli(usu);

            return Usuarios;
        }
    }
}
