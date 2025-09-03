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
    public class CUHistorialDeCitas : ICUCitas
    {
        private IRepositorioCita _RepoCita;
        private IRepositorioUsuario _Usuario;
        private IRepositorioCliente _RepoCliente;

        public CUHistorialDeCitas(IRepositorioCita _RepositorioCita)
        {
            _RepoCita = _RepositorioCita;
        }


       public List<DtoHistorialDeCitas> CitasPorCliente(int id)
        {
            List < Cita> Cita=_RepoCita.FindByIdLista(id);
            List<DtoHistorialDeCitas>dto=MapperCita.DeCitaADto(Cita);

            return (dto);
        }

     

   
        public List<DtoHistorialDeCitas> HisorialDeCitas()
        {

            List<Cita>Citas=_RepoCita.FindAll();
            List<DtoHistorialDeCitas> historialDeCitas = MapperCita.DeCitasDtoCitas(Citas);

            return historialDeCitas;

        }

        public List<DtoHistorialDeCitas> HistorialCitasPorCliente(int? id)
        {   
            List<Cita>Citas=_RepoCita.FindByIdLista(id);

            List<DtoHistorialDeCitas> DtoHistorial = MapperCita.DeCitasDtoCitas(Citas);

            return DtoHistorial;    

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
    }
}
