using DTOs;
using DTOs.CitaDTOs;
using LogicaAplicacion.InterfacesCU.ICUCita;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUCita
{
    public class CUGestionDeCitas:ICUCitas
    {
        private readonly IRepositorio<Cita> _RepoCita;

        public CUGestionDeCitas(IRepositorio<Cita> repoCita)
        {
            _RepoCita = repoCita;
        }

        public DtoCita GetEditar(int id)
        {
            Cita cita = _RepoCita.FindById(id);
            DtoCita dto = MapperCita.DeCitaADto(cita);
            return dto;
        }

        public void PostEditar(DtoCita dto)
        {
            Cita cita = _RepoCita.FindById(dto.Id);
            if (cita == null)
            {
                throw new Exception("La cita no es válida o no existe.");
            }

            cita.FechaHora = dto.FechaHora;
            cita.Estado = dto.Estado;
            cita.ClienteId = dto.ClienteId;
            cita.EmpleadoId = dto.EmpleadoId;
            cita.ServicioId = dto.ServicioId;

            _RepoCita.Update(cita);
        }

        public DtoCita GetEliminar(int id)
        {
            Cita cita = _RepoCita.FindById(id);
            DtoCita dto = MapperCita.DeCitaADto(cita);
            return dto;
        }

        public void PostEliminar(DtoCita dto)
        {
            Cita cita = MapperCita.DeDtoACita(dto);
            _RepoCita.Remove(cita.Id);
        }

        public List<DtoHistorialDeCitas> HisorialDeCitas()
        {
            throw new NotImplementedException();
        }

        public List<DtoHistorialDeCitas> HistorialCitasPorCliente(int? id)
        {
            throw new NotImplementedException();
        }
    }

}
