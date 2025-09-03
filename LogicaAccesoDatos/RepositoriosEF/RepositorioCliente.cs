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
    public class RepositorioCliente : IRepositorioCliente
    {
        private ApplicationDbContext _Context;

        public RepositorioCliente(ApplicationDbContext context)
        {
            _Context = context;
        }

       

        public void Add(Cliente nuevo)
        {
            _Context.Add(nuevo);
            _Context.SaveChanges();

            var clienteId = nuevo.Id;

        }

        public List<Cliente> FindAll()
        {
            return _Context.Clientes.ToList();
        }

        public Cliente FindById(int id)
        {
            return _Context.Clientes.Where(x => x.Id == id).SingleOrDefault();
        }

        public Cliente FindByEmail(string email)
        {
            return _Context.Clientes.Where(e => e.Email == email).SingleOrDefault();
        }

        public int FindByEmailParaId(string email)
        {
            var clienteId = _Context.Clientes
                                    .Where(c => c.Email == email)
                                    .Select(c => c.Id)
                                    .FirstOrDefault();

            if (clienteId == 0)
            {
                throw new Exception($"No se encontró un cliente con el email: {email}");
            }

            return clienteId;
        }



        public int FindByIdUsuActual(Usuario usuario)
        {
            var clienteId = _Context.Clientes
               .Where(c => c.Email == usuario.Email)
               .Select(c => c.Id)
               .FirstOrDefault();

            return clienteId;
        }
        public void Remove(int id)
        {
            Cliente aBorrar = _Context.Clientes.Find(id);
            _Context.Clientes.Remove(aBorrar);
            _Context.SaveChanges();
        }

        public void Update(Cliente obj)
        {
            _Context.Clientes.Update(obj);
            _Context.SaveChanges();
        }
    }
}
