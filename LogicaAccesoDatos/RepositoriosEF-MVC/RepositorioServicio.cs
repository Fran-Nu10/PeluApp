using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios.InterfacesMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositoriosEF
{
    public class RepositorioServicio : IRepositorioServicio
    {
        private ApplicationDbContext _context;
        public RepositorioServicio(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Servicio nuevo)
        {
            _context.Add(nuevo);
            _context.SaveChanges();
        }

        public List<Servicio> FindAll()
        {
            return _context.Servicios.ToList();
        }

        public Servicio FindById(int id)
        {
            return _context.Servicios.Where(s => s.Id == id).SingleOrDefault();
        }

        public List<Servicio> FindByIdList(List<int> Serv)
        {
            return _context.Servicios
                           .Where(s => Serv.Contains(s.Id))  // Filtra los servicios cuyo Id esté en la lista Serv
                           .ToList();
        }


 

        public void Remove(int id)
        {
            var servicio = _context.Servicios.FirstOrDefault(s => s.Id == id);
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
                _context.SaveChanges();
            }
        }

        public void Update(Servicio obj)
        {
            var servicio = _context.Servicios.FirstOrDefault(s => s.Id == obj.Id);
            if (servicio != null)
            {
                servicio.Nombre = obj.Nombre;
                servicio.Descripcion = obj.Descripcion;
                servicio.Precio = obj.Precio;
                servicio.Duracion = obj.Duracion;

                _context.Servicios.Update(servicio);
                _context.SaveChanges();
            }
        }

    }
}
