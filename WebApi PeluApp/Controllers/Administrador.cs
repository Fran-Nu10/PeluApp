using DTOs.CitaDTOs;
using DTOs.ClienteDTOs;
using DTOs.EmpleadoDTOs;
using DTOs.ServicioDTOs;
using LogicaAplicacion.InterfacesCU.ICUCita;
using LogicaAplicacion.InterfacesCU.ICUCliente;
using LogicaAplicacion.InterfacesCU.ICUEmpleado;
using LogicaAplicacion.InterfacesCU.ICUServicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_PeluApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        private readonly ICUGestionDeClientes _CUGestionDeClientes;
        private readonly ICUCitas _CUCitas;
        private readonly ICUGestionDeServicios _CUGestionDeServicios;
        private readonly ICUGestionDeEmpleados _CUGestionDeEmpleados;

        public AdministradorController(ICUGestionDeClientes cUGestionDeClientes,
                                       ICUGestionDeServicios cUGestionDeServicios,
                                       ICUGestionDeEmpleados _cUGestionDeEmpleados)
        {
            _CUGestionDeClientes = cUGestionDeClientes;
            _CUGestionDeServicios = cUGestionDeServicios;
            _CUGestionDeEmpleados = _cUGestionDeEmpleados;
        }

        // Endpoint para obtener horarios disponibles
        [HttpGet("horarios-disponibles")]
        public IActionResult ObtenerHorariosDisponibles([FromQuery] DtoCita dtoCita, [FromQuery] List<int> servicioId, [FromQuery] int empleadoId)
        {
            try
            {
                DtoEmpleado dto = _CUGestionDeEmpleados.EncontrarEmpleado(empleadoId);
                List<DateTime> horariosDisponibles = _CUGestionDeEmpleados.ObtenerHorariosDisponibles(dto, dtoCita.FechaHora);
                return Ok(horariosDisponibles);  // Devuelve los horarios disponibles en formato JSON
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Endpoint para crear un nuevo servicio
        [HttpPost("crear-servicio")]
        public IActionResult CrearServicio([FromBody] DtoServicioAPI dto)
        {
            try
            {
                _CUGestionDeServicios.AgregarServicioAPI(dto);
                return Ok("Se creo con exito");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Endpoint para mostrar todos los servicios
        [HttpGet("mostrar-servicios")]
        public IActionResult MostrarServicios()
        {
            try
            {
                var servicios = _CUGestionDeServicios.TodosLosServiciosDtoServicio();
                return Ok(servicios);  // Devuelve todos los servicios en formato JSON
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost("crear-cliente")]
        public IActionResult CrearCliente([FromBody] DtoCrearCliente dto)
        {
            try
            {
                _CUGestionDeClientes.CrearCliente(dto);  

                // Devolver JSON explícitamente
                return new JsonResult(new { mensaje = "Cliente creado correctamente", datos = dto });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { error = ex.Message }) { StatusCode = 400 };
            }
        }

        // Endpoint para obtener todos los clientes
        [HttpGet("todos-los-clientes")]
        public IActionResult TodosLosClientes()
        {
            try
            {
                var clientes = _CUGestionDeClientes.TodosLosClientes();
                return Ok(clientes);  // Devuelve todos los clientes en formato JSON
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // Endpoint para editar un cliente
        [HttpPut("editar-cliente/{id}")]
        public IActionResult EditarCliente(int id, [FromBody] DtoClienteAEditar dto)
        {
            try
            {
                _CUGestionDeClientes.PostEditar(dto);
                return Ok(dto);  // Cliente editado con éxito
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("eliminar-cliente")]
        public IActionResult EliminarCliente([FromBody] DtoClienteAEditar dto)
        {
            try
            {
                _CUGestionDeClientes.PostEliminar(dto);  // Elimina el cliente usando el DTO
                return NoContent();  // El cliente fue eliminado con éxito
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");  // Manejo de errores
            }
        }


        // Endpoint para ver detalles de un cliente
        [HttpGet("cliente/{id}")]
        public IActionResult VerCliente(int id)
        {
            try
            {
                var cliente = _CUGestionDeClientes.GetEditar(id);
                return Ok(cliente);  // Devuelve el cliente en formato JSON
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }

}
