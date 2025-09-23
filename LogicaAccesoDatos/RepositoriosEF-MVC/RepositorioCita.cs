using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios.InterfacesMVC;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositoriosEF
{
    public class RepositorioCita : IRepositorioCita
    {
        private ApplicationDbContext _context;

        public RepositorioCita(ApplicationDbContext context)
        {
            _context = context;
        }



        public List<Cita> FindByIdLista(int? id)
        {
            return _context.Citas.Where(c=>c.ClienteId == id).Include(c=>c.Cliente).Include(c=>c.Servicio).Include(c=>c.Empleado).ToList();
        }

        public void Add(Cita nuevo)
        {
            _context.Citas.Add(nuevo);
            _context.SaveChanges();
        }
            
        public List<Cita> FindAll()
        {
            return _context.Citas
      .Include(a => a.Cliente)    // Incluir toda la entidad Cliente
      .Include(a => a.Empleado)   // Incluir toda la entidad Empleado
      .Include(a => a.Servicio)   // Incluir toda la entidad Servicio
      .ToList();

        }

        public Cita FindById(int id)
        {
            return _context.Citas.FirstOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            var cita = FindById(id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
                _context.SaveChanges();
            }
        }

        public void Update(Cita obj)
        {
            var cita = FindById(obj.Id);
            if (cita != null)
            {
                cita.FechaHora = obj.FechaHora;
                cita.Estado = obj.Estado;
                cita.EmpleadoId = obj.EmpleadoId;
                cita.ClienteId = obj.ClienteId;
                cita.ServicioId = obj.ServicioId;

                _context.Citas.Update(cita);
                _context.SaveChanges();
            }
        }


        public List<Cita> MostrarServiciosClientes(int? id)
        {
            var e= _context.Citas.Where(c=>c.ClienteId==id).Include(c=>c.Servicio).ToList();
            return e;
                 
        }
    } 
}
