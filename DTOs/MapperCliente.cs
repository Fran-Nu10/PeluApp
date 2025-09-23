using DTOs.ClienteDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperCliente
    {



        public static Cliente DeUsuarioACliente(Usuario usuario)
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = usuario.Nombre;
            cliente.Apellido = usuario.Apellido;
            cliente.Email = usuario.Email;
            cliente.constrasenia = usuario.Contrasena;  // Se ajusta la propiedad para que coincida
            cliente.FechaCreacion = usuario.FechaRegistro;  // Asegúrate de que la propiedad de 'FechaCreacion' existe en Cliente
            cliente.Rol = usuario.Rol;
            return cliente;
        }

        public static Cliente DeDtoACliente(DtoCrearCliente dto)
        {
            Cliente Nuevo=new Cliente();
            Nuevo.Nombre = dto.Nombre;
            Nuevo.Apellido = dto.Apellido;
            Nuevo.constrasenia = dto.Constrasenia;
            Nuevo.Telefono = dto.Telefono;
            Nuevo.FechaCreacion = dto.FechaCreacion;
            Nuevo.Email = dto.Email;
            Nuevo.Rol = "Cliente";

            return Nuevo;   
        }

        public static Cliente DeDtoACliente(DtoClienteAEditar dto)
        {
            Cliente Nuevo = new Cliente();
            Nuevo.Id = dto.Id;
            Nuevo.Nombre = dto.Nombre;
            Nuevo.Apellido = dto.Apellido;
            Nuevo.constrasenia = dto.constrasenia;
            Nuevo.Telefono = dto.Telefono;
            Nuevo.FechaCreacion = dto.FechaCreacion;
            Nuevo.Email = dto.Email;
            Nuevo.Rol = "Cliente";

            return Nuevo;
        }


        public static DtoClienteAEditar DeClienteADto(Cliente cliente)
        {
            // Crear una nueva instancia de DtoNuevoCliente
            DtoClienteAEditar dto = new DtoClienteAEditar();

            // Mapear las propiedades del modelo Cliente al DTO
            dto.Id = cliente.Id;
            dto.Nombre = cliente.Nombre;
            dto.Apellido = cliente.Apellido;
            dto.constrasenia = cliente.constrasenia; // Asegúrate de no exponer la contraseña sin encriptar
            dto.Telefono = cliente.Telefono;
            dto.FechaCreacion = cliente.FechaCreacion;
            dto.Email = cliente.Email;

            // Retornar el DTO
            return dto;
        }



        public static List<DtoListarCliente> DeListaClienteAListaDto(List<Cliente> lista) 
        { 
        List<DtoListarCliente> ListaCliente=new List<DtoListarCliente>();

            foreach (Cliente c in lista) 
            {
                ListaCliente.Add(new DtoListarCliente(c.Id,c.Nombre, c.Apellido, c.Telefono, c.Email, c.constrasenia, c.FechaCreacion));
            }
            
            return ListaCliente;

           
        
        }

       

    }
}
