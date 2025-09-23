using LogicaAccesoDatos.RepositoriosEF;
using LogicaAplicacion.InterfacesCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            // Aquí EF Core guarda todo lo pendiente en la base
            return _db.SaveChangesAsync(ct);
        }
    }

}
