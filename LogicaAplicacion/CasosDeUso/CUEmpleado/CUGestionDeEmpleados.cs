using DTOs;
using DTOs.CitaDTOs;
using DTOs.EmpleadoDTOs;
using LogicaAplicacion.InterfacesCU.ICUEmpleado;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.CUEmpleado
{
    public class CUGestionDeEmpleados : ICUGestionDeEmpleados
    {
        private IRepositorioEmpleado _RepoEmpleado;

        public CUGestionDeEmpleados(IRepositorioEmpleado repo)
        {
            _RepoEmpleado = repo;
        }

        public void RegistrarEmpleado(DtoEmpleado dto)
        {
           

            ValidarEmpleado(dto);

            Empleado empleado = MapperEmpleado.DeDtoAEmpleado(dto);
           
            // Verificar si el empleado ya existe
            Empleado empleadoExistente = _RepoEmpleado.FindByIdEmpleado(empleado.Id);

            if (empleadoExistente != null)
            {
                throw new Exception("El empleado ya existe.");
            }

            _RepoEmpleado.Add(empleado);


        }
        public List<DtoEmpleado> TodosLosEmpleados()
        {
            List<Empleado> empleados = _RepoEmpleado.FindAll();

            List<DtoEmpleado> DtoEmpleados = MapperEmpleado.DeListaEmpleadoADto(empleados);

            return DtoEmpleados;
        }
        public List<DateTime> ObtenerHorariosDisponibles(DtoEmpleado empleado, DateTime fecha)
        {
            Empleado Empleado = _RepoEmpleado.FindByIdEmpleado(empleado.Id);
            // Define la duración estándar de una cita (por ejemplo, 1 hora)
            TimeSpan duracionCita = TimeSpan.FromHours(1);

            // Genera todos los horarios posibles dentro del rango de trabajo del empleado
            List<DateTime> horariosPosibles = new List<DateTime>();//creo lista para guardar Horarios posibles 
            DateTime inicio = fecha.Date + Empleado.HoraInicio;
            DateTime fin = fecha.Date + Empleado.HoraFin;

            while (inicio < fin)
            {
                horariosPosibles.Add(inicio);
                inicio = inicio.Add(duracionCita);
            }

            // Filtra los horarios ocupados basados en las citas existentes
            List<DateTime> horariosOcupados = _RepoEmpleado.DevolverHorariosOcupados(Empleado, horariosPosibles);

            List<DateTime> horariosLibres = _RepoEmpleado.DevolverHorariosLibres(horariosOcupados, horariosPosibles);

            return horariosLibres;


        }

        public DtoEmpleado EncontrarEmpleado(int id)
        {
            Empleado empleado = _RepoEmpleado.FindById(id);
            DtoEmpleado dto = MapperEmpleado.DeEmpleadoADto(empleado);
            return dto;
        }

        public void ValidarEmpleado(DtoEmpleado empleado)
        {
            // Validación del nombre
            if (string.IsNullOrWhiteSpace(empleado.Nombre))
            {
                throw new Exception("El nombre no puede estar vacío.");
            }
            // Validación del apellido
            if (string.IsNullOrWhiteSpace(empleado.Apellido))
            {
                throw new Exception("El apellido no puede estar vacío.");
            }
            // Validación del cargo
            if (string.IsNullOrWhiteSpace(empleado.Cargo))
            {
                throw new Exception("El cargo no puede estar vacío.");
            }
            // Validación del teléfono
            if (string.IsNullOrWhiteSpace(empleado.Telefono) || empleado.Telefono.Length < 6)
            {
                throw new Exception("El teléfono debe ser un número válido y tener al menos 6 dígitos.");
            }
            // Validación del salario
            if (empleado.Salario <= 0)
            {
                throw new Exception("El salario debe ser un valor positivo.");
            }

        }
    }
}
