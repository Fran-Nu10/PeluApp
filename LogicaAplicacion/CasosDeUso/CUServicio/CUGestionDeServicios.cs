using DTOs;
using DTOs.CitaDTOs;
using DTOs.ServicioDTOs;
using LogicaAplicacion.InterfacesCU.ICUServicio;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUServicio
{
    public class CUGestionDeServicios : ICUGestionDeServicios
    {
        private IRepositorioServicio _RepoServicio;

        public CUGestionDeServicios(IRepositorioServicio _RepositorioServicio)
        {
            _RepoServicio = _RepositorioServicio;
        }

        public void AgregarServicio(DtoServicio dto)
        {

            Servicio Ser = MapperServicio.DeServicioADto(dto);

            _RepoServicio.Add(Ser);
        }
        public List<DtoCita> TodosLosServicios()
        {
            List<Servicio> Servicios = _RepoServicio.FindAll();
            List<DtoCita> Dto = MapperServicio.DeServicioADto(Servicios);
            return Dto;
        }
        //Hgao uno giual pero con DtoServicio
        public List<DtoServicio> TodosLosServiciosDtoServicio()
        {
            List<Servicio> Servicios = _RepoServicio.FindAll();
            List<DtoServicio> Dto = MapperServicio.DeServicioADtoServicio(Servicios);
            return Dto;
        }


        public DtoServicio GetEditar(int id)
        {
            Servicio serv = _RepoServicio.FindById(id);
            return MapperServicio.DeServicioADto1(serv);
        }

        public void PostEditar(DtoServicio dto)
        {
            Servicio serv = _RepoServicio.FindById(dto.Id);
            if (serv == null)
            {
                throw new Exception("El servicio no es válido o no existe.");
            }
            serv.Nombre = dto.Nombre;
            serv.Descripcion = dto.Descripcion;
            serv.Precio = dto.Precio;
            serv.Duracion = dto.Duracion;

            _RepoServicio.Update(serv);
        }

        public DtoServicio GetEliminar(int id)
        {
            Servicio serv = _RepoServicio.FindById(id);
            return MapperServicio.DeServicioADto1(serv);
        }

        public void PostEliminar(DtoServicio dto)
        {
            _RepoServicio.Remove(dto.Id);
        }

        public void AgregarServicioAPI(DtoServicioAPI dto)
        {
            Servicio ser = MapperServicio.DeServicioADtoAPI(dto);

            _RepoServicio.Add(ser);
        }
    }
}
