using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios.InterfacesMVC;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LogicaAccesoDatos.RepositoriosEF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ApplicationDbContext _context;

        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;
            
        }



        public Usuario BuscarPorMail(string email,string contra)
        {
             return _context.Usuarios.Where(u=>u.Email==email&&u.Contrasena==contra).FirstOrDefault();
        }

        public void Add(Usuario nuevo)
        {
            _context.Add(nuevo);
            _context.SaveChanges();

        }

        public List<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

       

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }

       

        public Usuario FindByIdUsu(int? id)
        {
            return _context.Usuarios.Where(x => x.Id == id).SingleOrDefault();
        }

        public Usuario FindById(int id)
        {
            return _context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
        }

        public Usuario FindByIdUsuario(int? id)
        {
            return _context.Usuarios.Where(u => u.Id == id).FirstOrDefault();
        }

        public Usuario FindByIdPerfil(int? idUsuario)
        {
            return _context.Usuarios.Where(u => u.Id == idUsuario).FirstOrDefault();
        }
    }
}
