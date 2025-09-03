using DTOs.CitaDTOs;
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
    public class MapperServicio
    {

        public static List<DtoCita> DeServicioADto(List<Servicio> servicios)
        {
            List<DtoCita> dtoServicios = new List<DtoCita>();

            foreach (Servicio servicio in servicios)
            {
                // Agregar cada DtoServicio a la lista
                dtoServicios.Add(new DtoCita(servicio.Id,servicio.Nombre));
            }

            // Devolver la lista completa de DtoServicio
            return dtoServicios;
        }


        public static List<DtoServicio> DeServicioADtoServicio(List<Servicio> servicios)
        {
            List<DtoServicio> dtoServicios = new List<DtoServicio>();

            foreach (Servicio servicio in servicios)
            {
                // Agregar cada DtoServicio a la lista
                dtoServicios.Add(new DtoServicio(servicio.Id, servicio.Nombre,servicio.Descripcion,servicio.Precio,servicio.Duracion));
            }

            // Devolver la lista completa de DtoServicio
            return dtoServicios;
        }

        public static List<DtoServicio> DeListaServicioADto(List<Servicio> servicios)
        {
            List<DtoServicio> dtoServicios = new List<DtoServicio>();

            foreach (Servicio servicio in servicios)
            {
                // Agregar cada DtoServicio a la lista
                dtoServicios.Add(new DtoServicio(servicio.Id, servicio.Nombre,servicio.Descripcion,servicio.Precio,servicio.Duracion));
            }

            // Devolver la lista completa de DtoServicio
            return dtoServicios;
        }


        public static Servicio DeServicioADto(DtoServicio E)
        {
            Servicio s = new Servicio();

            s.Nombre = E.Nombre;
            s.Descripcion = E.Descripcion;
            s.Precio = E.Precio;
            s.Duracion = E.Duracion;

            return s;
        }
        public static DtoServicio DeServicioADto1(Servicio E)
        {
            DtoServicio s = new DtoServicio();
            s.Id = E.Id;
            s.Nombre = E.Nombre;
            s.Descripcion = E.Descripcion;
            s.Precio = E.Precio;
            s.Duracion = E.Duracion;

            return s;
        }

        public static int DeServicioADtoo(Servicio E)
        {
            int s = 0;

            s = E.Id;

            return s;
        }


    }
}
