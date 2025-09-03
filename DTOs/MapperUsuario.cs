using DTOs.UsuarioDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperUsuario
    {

        public static Usuario DeDtoCliAUsuario(DtoRegistroUsuario dto)
        {
            Usuario nuevo = new Usuario();
            nuevo.Id = dto.Id;
            nuevo.Nombre = dto.Nombre;
            nuevo.Apellido = dto.Apellido;
            nuevo.Email = dto.Email;
            nuevo.Telefono = dto.Telefono;
            nuevo.Contrasena = dto.Contrasena;
            nuevo.FechaRegistro = dto.FechaRegistro;
            nuevo.Rol = "Usuario";

            return nuevo;
        }

        public static DtoUsuario DeUsuarioADtoCli(Usuario Usu)
        {
            DtoUsuario nuevo = new DtoUsuario();
            nuevo.Id = Usu.Id;
            nuevo.Nombre = Usu.Nombre;
            nuevo.Apellido = Usu.Apellido;
            nuevo.Email = Usu.Email;
            nuevo.Telefono = Usu.Telefono;
            nuevo.Contrasena = Usu.Contrasena;
            nuevo.FechaRegistro = Usu.FechaRegistro;

            return nuevo;
        }

        public static DtoLogin DeUsuarioLoginaDtoLogin(Usuario Usu)
        {
            DtoLogin nuevo = new DtoLogin();
            nuevo.Id = Usu.Id;
            nuevo.Nombre = Usu.Nombre;
            nuevo.Apellido = Usu.Apellido;
            nuevo.Email = Usu.Email;
            nuevo.Telefono = Usu.Telefono;
            nuevo.Contrasena = Usu.Contrasena;
            nuevo.FechaRegistro = Usu.FechaRegistro;
            nuevo.Rol = Usu.Rol;
           

            return nuevo;
        }


        public static List<DtoUsuario> DeUsuarioADtoUsuario(List<Usuario> usuarios)
        {
            // Crear la lista de retorno
            List<DtoUsuario> listaDto = new List<DtoUsuario>();

            // Verificar si la lista de usuarios no es nula
            if (usuarios != null)
            {
                // Recorrer la lista de usuarios
                foreach (var usuario in usuarios)
                {
                    // Crear una instancia de DtoLogin
                    DtoUsuario dto = new DtoUsuario
                    {
                        Contrasena = usuario.Contrasena,
                        Email = usuario.Email,
                        Telefono = usuario.Telefono,
                        Id = usuario.Id,
                        Activo = usuario.Activo,
                        FechaRegistro = usuario.FechaRegistro,
                        Rol = usuario.Rol,
                        Nombre = usuario.Nombre,
                        Apellido = usuario.Apellido
                    };

                    // Agregar el DtoLogin a la lista de retorno
                    listaDto.Add(dto);
                }
            }

            return listaDto;
        }

    }
}
