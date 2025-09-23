using LogicaAplicacion.InterfacesCU.ICUCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Entidades;
using DTOs;
using DTOs.UsuarioDTOs;
using LogicaNegocio.InterfacesRepositorios.InterfacesMVC;

namespace LogicaAplicacion.CasosDeUso.CUCliente
{
    public class CURegistrarCliente : ICURegistrarCliente
    {
        private IRepositorioUsuario _repoUsu;

        public CURegistrarCliente(IRepositorioUsuario CURegistrarCliente)
        {
            _repoUsu = CURegistrarCliente;
        }
        public void RegistroCliente(DtoRegistroUsuario Cli)
        {
            Validar(Cli);
            Usuario ClienteNuevo=MapperUsuario.DeDtoCliAUsuario(Cli);
            ClienteNuevo.FechaRegistro=DateTime.Now;
            _repoUsu.Add(ClienteNuevo);
        }


        public void Validar(DtoRegistroUsuario cliente)
        {
            // Validación del nombre
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                throw new Exception("El nombre no puede estar vacío.");
            }

            // Validación del apellido
            if (string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                throw new Exception("El apellido no puede estar vacío.");
            }

            // Validación de la contraseña
            if (string.IsNullOrWhiteSpace(cliente.Contrasena))
            {
                throw new Exception("La contraseña no puede estar vacía.");
            }
            if (cliente.Contrasena.Length < 6)
            {
                throw new Exception("La contraseña debe tener al menos 6 caracteres.");
            }

            // Validación del teléfono
            //if (cliente.Telefono <= 0)
            //{
            //    throw new Exception("El teléfono debe ser un número válido.");
            //}
            if (cliente.Telefono.ToString().Length < 6) // Asumiendo que el teléfono debe tener al menos 10 dígitos
            {
                throw new Exception("El teléfono debe tener al menos 6 dígitos.");
            }

            // Validación del correo electrónico
            if (string.IsNullOrWhiteSpace(cliente.Email))
            {
                throw new Exception("El correo electrónico no puede estar vacío.");
            }
            if (!cliente.Email.Contains("@"))
            {
                throw new Exception("El correo electrónico debe contener '@'.");
            }
           
        }

    }
}
