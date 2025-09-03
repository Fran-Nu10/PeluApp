using DTOs.CitaDTOs;
using DTOs.ClienteDTOs;
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
    public class MapperCita
    {


        public static List<Cita> 
        public static List<DtoCita> DeListaCitasADtoServicios(List<Cita>Citas)
        {
            List<DtoCita>dto=new List<DtoCita>();

            foreach (Cita cita in Citas)
            {
                if (cita.Servicio != null) // Asegúrate de que el servicio no sea nulo
                {
                    // Crea un nuevo DtoCita
                    var dtoCita = new DtoCita
                    {
                        Id = cita.Id,
                        FechaHora = cita.FechaHora,
                        ClienteId = cita.ClienteId,
                        EmpleadoId = cita.EmpleadoId,
                        Estado = cita.Estado,
                        // Mapea los servicios de la cita hacia la lista de DtoServicio
                       
         
                    };

                    // Agrega el DtoCita a la lista
                    dto.Add(dtoCita);
                }
            }


            return dto;
        }


        public static List<DtoHistorialDeCitas> DeCitaADto(List<Cita> citas)
        {
            List<DtoHistorialDeCitas> dtos = new List<DtoHistorialDeCitas>();

            foreach (var cita in citas)
            {
                DtoHistorialDeCitas dto = new DtoHistorialDeCitas
                {
                    Id = cita.Id,
                    ClienteId = cita.ClienteId,
                   
                  
                    Estado = cita.Estado,
                    FechaHora = cita.FechaHora,
                    EmpleadoId = cita.EmpleadoId,
                    ServicioId = cita.ServicioId
                };

                dtos.Add(dto);
            }

            return dtos;
        }


        public static Cita DeDtoACita(DtoCita dto, int idCliente, int ServicioId, Servicio ser, int EmpleadoId)
        {
            // Crear una nueva instancia de Cita
            Cita cita = new Cita
            {
                FechaHora = dto.FechaHora,
                Id = dto.Id,
                Estado = dto.Estado,
                ClienteId = idCliente,
                EmpleadoId = EmpleadoId,
                ServicioId = ServicioId,
                // Inicializar el objeto Servicio
                Servicio = new Servicio
                {
                    Nombre = ser.Nombre,
                    Descripcion = ser.Descripcion,
                    Precio = ser.Precio,
                    Duracion = ser.Duracion
                }
            };

            return cita;
        }


        public static List<DtoHistorialDeCitas> DeCitasDtoCitas(List<Cita> Citas)
        {
            List<DtoHistorialDeCitas> DtoCitas = new List<DtoHistorialDeCitas>();

            foreach (Cita C in Citas)
            {
                // Aquí se asignan los objetos relacionados, como Cliente, Empleado, Servicio
                // Y solo se asigna el nombre de cada uno de esos objetos a los DTOs correspondientes.

                Cliente cli=C.Cliente;
                Empleado empl=C.Empleado;
                Servicio servicio=C.Servicio;


                DtoCitas.Add(new DtoHistorialDeCitas(
                    C.Id,
                    C.FechaHora,
                    C.ClienteId,
                    new DtoListarCliente { Nombre = C.Cliente.Nombre }, // Solo el nombre del Cliente
                    C.EmpleadoId,
                    new DtoEmpleado { Nombre = C.Empleado.Nombre }, // Solo el nombre del Empleado
                    C.ServicioId,
                    new DtoServicio { Nombre = C.Servicio.Nombre }, // Solo el nombre del Servicio
                    C.Estado
                ));
            }

            return DtoCitas;
        }


        public static DtoCita DeCitaADto(Cita cita)
        {
            return new DtoCita
            {
                Id = cita.Id,
                FechaHora = cita.FechaHora,
                Estado = cita.Estado,
                ClienteId = cita.ClienteId,
                EmpleadoId = cita.EmpleadoId,
                ServicioId = cita.ServicioId
            };
        }

        public static Cita DeDtoACita(DtoCita dto)
        {
            return new Cita
            {
                Id = dto.Id,
                FechaHora = dto.FechaHora,
                Estado = dto.Estado,
                ClienteId = dto.ClienteId,
                EmpleadoId = dto.EmpleadoId,
                ServicioId = dto.ServicioId
            };
        }
        public static List<Cita> DeListaDtoACitas(List<DtoCita> dtos)
        {
            List<Cita> citas = new List<Cita>();

            foreach (var dto in dtos)
            {
                Cita cita = new Cita
                {
                    Id = dto.Id,
                    FechaHora = dto.FechaHora,
                    Estado = dto.Estado,
                    ClienteId = dto.ClienteId,
                    EmpleadoId = dto.EmpleadoId,
                    ServicioId = dto.ServicioId,
                    Servicio = dto.Servicio != null ? new Servicio
                    {
                        Id = dto.Servicio.Id,
                        Nombre = dto.Servicio.Nombre,
                        Descripcion = dto.Servicio.Descripcion,
                        Precio = dto.Servicio.Precio,
                        Duracion = dto.Servicio.Duracion
                    } : null
                };

                citas.Add(cita);
            }

            return citas;
        }
    }
}
