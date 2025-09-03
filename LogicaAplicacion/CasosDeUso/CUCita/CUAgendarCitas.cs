using DTOs.CitaDTOs;
using DTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCU.ICUCita;

namespace LogicaAplicacion.CasosDeUso.CUCita
{
    public class CUAgendarCitas: ICUAgendarCitas
    {
        private IRepositorioCita _RepoCita;
        private IRepositorioUsuario _Usuario;
        private IRepositorioCliente _RepoCliente;
        private IRepositorioServicio _RepoServicio;
        private IRepositorioEmpleado _RepoEmpleado;

        public CUAgendarCitas(IRepositorioCita _RepositorioCita,IRepositorioUsuario usu,IRepositorioCliente cli,IRepositorioServicio ser,IRepositorioEmpleado repoE)
        {
            _RepoCita = _RepositorioCita;
            _Usuario = usu;
            _RepoCliente = cli;
            _RepoServicio = ser;
            _RepoEmpleado = repoE;
        }
        public void AgendarCita(DtoCita dto, int? usuId,int EmpleadoId,int ServiciosId)
        {
            Usuario usuario = _Usuario.FindByIdUsu(usuId);//me quedo con el usuario que quiere hacer la cita

            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            if (usuario.Rol == "Cliente")
            {
                Cliente Cli = _RepoCliente.FindByEmail(usuario.Email);

                dto.ClienteId = Cli.Id;
            }
          

            Servicio Servicios = _RepoServicio.FindById(ServiciosId);

            dto.ServicioId=MapperServicio.DeServicioADtoo(Servicios);

          Empleado E = _RepoEmpleado.FindById(EmpleadoId);

            dto.empleado = MapperEmpleado.DeEmpleadoADto(E);



            int Empleadoid = dto.EmpleadoId;
            int servicioId = dto.ServicioId;

            Servicio Servicio =_RepoServicio.FindById(servicioId);


            if (usuario.Rol == "Usuario")//si es rol Usuario 
            {
                // Cambiar el rol a "Cliente"
                usuario.Rol = "Cliente";

               

                Cliente cli = MapperCliente.DeUsuarioACliente(usuario);//mapeo datos

                _RepoCliente.Add(cli);//agrego cita 

                // Obtener el ClienteId recién creado       
                var clienteId = cli.Id;

                Cita CitaNueva = MapperCita.DeDtoACita(dto,clienteId,servicioId,Servicio ,Empleadoid);//mapeo datos ya con el Id del Cliente

                _RepoCita.Add(CitaNueva);


            }
            else if (usuario.Rol == "Cliente")
            {
                int idCliente = _RepoCliente.FindByIdUsuActual(usuario);

                Cita CitaNueva = MapperCita.DeDtoACita(dto, idCliente,servicioId, Servicio, EmpleadoId);
                CitaNueva.Empleado=E;
                CitaNueva.Estado ="Pendiente";

                _RepoCita.Add(CitaNueva);
            }
         }

    }
}
