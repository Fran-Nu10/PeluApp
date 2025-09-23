        using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositoriosEF
{
    public class RepositorioEmpleado : IRepositorioEmpleado
    {
        private ApplicationDbContext _context;

        public RepositorioEmpleado(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Empleado nuevo)
        {
            _context.Empleados.Add(nuevo);
            _context.SaveChanges();
        }

        public List<DateTime> DevolverHorariosLibres(List<DateTime> horariosOcupados, List<DateTime>horariosPosibkles)
        {
            List<DateTime> horariosLibres = horariosPosibkles;
            // Devuelve solo los horarios libres
            return horariosLibres.Except(horariosOcupados).ToList();
        }

        public List<DateTime> DevolverHorariosOcupados(Empleado empleado, List<DateTime> horariosPosibles)
        {
            // Filtra las citas del empleado que coincidan con los horarios posibles
            return empleado.Citas
                .Where(c => horariosPosibles.Contains(c.FechaHora))
                .Select(c => c.FechaHora)
                .ToList();
        }

        //public Empleado FindByEmail(string email)
        //{
        //    return _context.Empleados.SingleOrDefault(e => e.e== email);
        //}
        public List<Empleado> FindAll()
        {
            return _context.Empleados.ToList();
        }

        public Empleado FindById(int id)
        {
            return _context.Empleados.Where(x => x.Id == id).SingleOrDefault();
        }

        public Empleado FindByIdEmpleado(int id)
        {
            return _context.Empleados.Where(e => e.Id == id).Include(e=>e.Citas).SingleOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Empleado obj)
        {
            _context.Empleados.Update(obj);
            _context.SaveChanges();

        }
    }
}
