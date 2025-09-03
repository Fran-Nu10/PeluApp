using DTOs.EmpleadoDTOs;
using DTOs.ServicioDTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MapperEmpleado
    {
        public static DtoEmpleado DeEmpleadoADto(Empleado E)
        {
            DtoEmpleado Dto = new DtoEmpleado();

            Dto.Id = E.Id;
            Dto.Nombre = E.Nombre;
            Dto.Apellido = E.Apellido;
            Dto.Telefono = E.Telefono;
            Dto.Salario = E.Salario;
            Dto.Cargo = E.Cargo;
            Dto.Rol = E.Rol;
            return Dto;
        }

        public static Empleado DeDtoAEmpleado(DtoEmpleado Dto)
        {
            Empleado E = new Empleado();
            E.Id = Dto.Id;
            E.Nombre = Dto.Nombre;
            E.Apellido = Dto.Apellido;
            E.Telefono = Dto.Telefono;
            E.Salario = Dto.Salario;
            E.Cargo = Dto.Cargo;
            E.Rol = Dto.Rol;
            return E;
        }

        public static List<DtoEmpleado> DeListaEmpleadoADto(List<Empleado> empleados)
        {
            List<DtoEmpleado> DtoEmpleados = new List<DtoEmpleado>();

            foreach (Empleado empleado in empleados)
            {
                // Agregar cada DtoServicio a la empleado
                DtoEmpleados.Add(new DtoEmpleado(empleado.Id,empleado.Nombre, empleado.Apellido, empleado.Cargo, empleado.Telefono, empleado.Salario));
            }

            // Devolver la lista completa de DtoServicio
            return DtoEmpleados;
        }
    }
}
