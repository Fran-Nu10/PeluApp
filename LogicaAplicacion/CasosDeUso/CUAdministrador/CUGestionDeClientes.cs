using DTOs;
using DTOs.ClienteDTOs;
using DTOs.UsuarioDTOs;
using LogicaAplicacion.InterfacesCU.ICUCliente;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUAdministrador
{
    public class CUGestionDeClientes : ICUGestionDeClientes
    {
        private IRepositorioCliente _RepoCliente;

        public CUGestionDeClientes(IRepositorioCliente _RepositorioCliente)
        {
            _RepoCliente = _RepositorioCliente;
        }
        public void CrearCliente(DtoNuevoCliente dtoCli)
        {
            ValidarCliente(dtoCli);

            Cliente NuevoCliente = MapperCliente.DeDtoACliente(dtoCli);

            _RepoCliente.Add(NuevoCliente);
        }

        public int EncontrarIdDeCliente(string email)
        {
            int IdCli = _RepoCliente.FindByEmailParaId(email);
            return IdCli;
        }

        public DtoClienteAEditar EncontrarCliente(string email)
        {
            Cliente cli=_RepoCliente.FindByEmail(email);
            DtoClienteAEditar dto=MapperCliente.DeClienteADto(cli);
            return dto;
        }


        public List<DtoNuevoCliente> TodosLosClientes()
        {
            List<Cliente>Clientes=_RepoCliente.FindAll();

            List<DtoNuevoCliente> DtoClientes=MapperCliente.DeListaClienteAListaDto(Clientes);

            return DtoClientes;
        }


        



        public DtoClienteAEditar GetEditar(int id)
        {
           Cliente cli= _RepoCliente.FindById(id);
                
            DtoClienteAEditar dto = MapperCliente.DeClienteADto(cli);

            return dto;
        }


        public void PostEditar(DtoClienteAEditar dto)
        {
            Cliente cli=_RepoCliente.FindById(dto.Id);
            if (cli == null)
            {
                throw new Exception("El Usuario no es válido o no existe.");
            }

            cli.Nombre = dto.Nombre;
            cli.Apellido = dto.Apellido;    
            cli.FechaCreacion = dto.FechaCreacion;
            cli.constrasenia = dto.constrasenia;
            cli.Email = dto.Email;
            cli.Telefono = dto.Telefono;

            _RepoCliente.Update(cli);

        }


        public DtoClienteAEditar GetEliminar(int id)
        {
            Cliente cli = _RepoCliente.FindById(id);

            DtoClienteAEditar dto = MapperCliente.DeClienteADto(cli);

            return dto;
        }


        public void PostEliminar(DtoClienteAEditar dtoo)
        {
            Cliente cli = MapperCliente.DeDtoACliente(dtoo);
            _RepoCliente.Remove(cli.Id);
        }


        public void ValidarCliente(DtoNuevoCliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                throw new ArgumentException("El nombre no puede estar vacío o ser solo espacios en blanco.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                throw new ArgumentException("El apellido no puede estar vacío o ser solo espacios en blanco.");
            }

            if (cliente.Telefono.ToString().Length < 8)
            {
                throw new ArgumentException("El número de teléfono debe tener al menos 8 dígitos.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Email) || !cliente.Email.Contains("@"))
            {
                throw new ArgumentException("El email debe ser válido y contener un '@'.");
            }

            if (string.IsNullOrWhiteSpace(cliente.constrasenia) || cliente.constrasenia.Length < 6)
            {
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");
            }

            if (cliente.FechaCreacion > DateTime.Now)
            {
                throw new ArgumentException("La fecha de creación no puede ser en el futuro.");
            }

        }

       
    }

}

