using LogicaAccesoDatos.RepositoriosEF;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios.InterfacesAPI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositoriosEF_API
{
    public class RepositorioClienteAPI : IRepositorioClienteAPI
    {
        private readonly ApplicationDbContext _db;

        public RepositorioClienteAPI(ApplicationDbContext db) => _db = db;

        public Task AddAsync(Cliente entity, CancellationToken ct)
            => _db.Clientes.AddAsync(entity, ct).AsTask();

        public Task<Cliente?> FindByIdAsync(int id, CancellationToken ct)
            => _db.Clientes.FirstOrDefaultAsync(c => c.Id == id, ct);

        public Task<Cliente?> FindByEmailAsync(string email, CancellationToken ct)
            => _db.Clientes.FirstOrDefaultAsync(c => c.Email == email, ct);

        public async Task<int> FindIdByEmailAsync(string email, CancellationToken ct)
        {
            var id = await _db.Clientes
                              .Where(c => c.Email == email)
                              .Select(c => c.Id)
                              .FirstOrDefaultAsync(ct);
            return id; // 0 si no existe
        }

        public Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
            => _db.Clientes.AnyAsync(c => c.Email == email, ct);


        public void Update(Cliente entity)
            => _db.Clientes.Update(entity); // marca como Modified

        public async Task RemoveByIdAsync(int id, CancellationToken ct)
        {
            var entity = await _db.Clientes.FirstOrDefaultAsync(c => c.Id == id, ct);
            if (entity is not null)
                _db.Clientes.Remove(entity);
        }

        //public async Task<(IReadOnlyList<Cliente> Items, int Total)> ListAsync(
        //    int pagina, int tamanio, string? buscar, CancellationToken ct)
        //{
        //    var query = _db.Clientes.AsNoTracking();

        //    if (!string.IsNullOrWhiteSpace(buscar))
        //    {
        //        var b = buscar.Trim();
        //        query = query.Where(c =>
        //            c.Nombre.Contains(b) || c.Apellido.Contains(b) || c.Email.Contains(b));
        //    }

        //    var total = await query.CountAsync(ct);

        //    var items = await query
        //        .OrderBy(c => c.Apellido).ThenBy(c => c.Nombre)
        //        .Skip((pagina - 1) * tamanio)
        //        .Take(tamanio)
        //        .ToListAsync(ct);

        //    return (items, total);
        //}

    }

}
