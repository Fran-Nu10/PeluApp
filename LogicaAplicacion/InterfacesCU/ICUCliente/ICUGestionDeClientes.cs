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

        List<DtoListarCliente> TodosLosClientes();

        DtoClienteAEditar GetEditar(int id);

        void PostEditar(DtoClienteAEditar dto);

        DtoClienteAEditar EncontrarCliente(string email);
        DtoClienteAEditar GetEliminar(int id);

        void PostEliminar(DtoClienteAEditar dtoo);

        int EncontrarIdDeCliente(string email);

        //METODOS ASYNC PARA API
        public Task<int> CrearClienteAPI(DtoCrearCliente dtoCli, CancellationToken ct);

        Task<Cliente?> FindByIdAsync(int id, CancellationToken ct);
        Task<Cliente?> FindByEmailAsync(string email, CancellationToken ct);
        Task<int> FindIdByEmailAsync(string email, CancellationToken ct);
        Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);

        // LIST (paginado + búsqueda)
       
        // UPDATE
        void Update(Cliente entity);      // solo marca cambios en el DbContext

        // DELETE
        Task RemoveByIdAsync(int id, CancellationToken ct);


    }
}
