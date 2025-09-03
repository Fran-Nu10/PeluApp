using DTOs;
using DTOs.CitaDTOs;
using DTOs.ServicioDTOs;
using LogicaAplicacion.InterfacesCU.ICUCliente;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.CUCliente
{
    public class CUMostrarServicios : ICUMostrarServicios
    {
        private IRepositorioCliente _RepoCliente;
        private IRepositorioCita _RepoCita;

        public CUMostrarServicios(IRepositorioCliente _RepositorioCliente, IRepositorioCita repoCita)
        {
            _RepoCliente = _RepositorioCliente;
            _RepoCita = repoCita;
        }
        public List<DtoCita> MostrarServiciosPorCliente(int id)
        {
             

           List<Cita>Citas= _RepoCita.MostrarServiciosClientes(id);


            List<DtoCita> dtoServicios = MapperCita.DeListaCitasADtoServicios(Citas);

            return dtoServicios;

        }
    }
}
