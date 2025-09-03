using DTOs.ClienteDTOs;
using DTOs.UsuarioDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.ICUCliente
{
    public interface ICUGestionDeClientes
    {
        public void CrearCliente(DtoCrearCliente dtoCli);
        List<DtoNuevoCliente> TodosLosClientes();

        DtoClienteAEditar GetEditar(int id);

        void PostEditar(DtoClienteAEditar dto);

        DtoClienteAEditar EncontrarCliente(string email);
        DtoClienteAEditar GetEliminar(int id);

        void PostEliminar(DtoClienteAEditar dtoo);

         int EncontrarIdDeCliente(string email);
    }
}
