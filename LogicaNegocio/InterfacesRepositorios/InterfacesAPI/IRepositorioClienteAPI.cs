using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios.InterfacesAPI
{
    public interface IRepositorioClienteAPI
    {
        // CREATE
        Task AddAsync(Cliente entity, CancellationToken ct);

        // READ
        Task<Cliente?> FindByIdAsync(int id, CancellationToken ct);
        Task<Cliente?> FindByEmailAsync(string email, CancellationToken ct);
        Task<int> FindIdByEmailAsync(string email, CancellationToken ct);
        Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);

        // LIST (paginado + búsqueda)
        //Task<(IReadOnlyList<Cliente> Items, int Total)> ListAsync(
        //    int pagina, int tamanio, string? buscar, CancellationToken ct);

        // UPDATE
        void Update(Cliente entity);      // solo marca cambios en el DbContext

        // DELETE
        Task RemoveByIdAsync(int id, CancellationToken ct);
    }

}
