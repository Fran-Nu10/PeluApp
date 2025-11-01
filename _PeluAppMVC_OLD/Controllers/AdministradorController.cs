using DTOs.CitaDTOs;
using DTOs.ClienteDTOs;
using DTOs.EmpleadoDTOs;
using DTOs.ServicioDTOs;
using LogicaAplicacion.CasosDeUso.CUEmpleado;
using LogicaAplicacion.InterfacesCU.ICUCita;
using LogicaAplicacion.InterfacesCU.ICUCliente;
using LogicaAplicacion.InterfacesCU.ICUEmpleado;
using LogicaAplicacion.InterfacesCU.ICUServicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PeluAppMVC.Controllers
{
    public class AdministradorController : Controller
    {

        private ICUGestionDeClientes _CUGestionDeClientes;
        private ICUCitas _CUCitas;
        private ICUGestionDeServicios _CUGestionDeServicios;
        private ICUGestionDeEmpleados _CUGestionDeEmpleados;
        


        public AdministradorController(ICUGestionDeClientes cUGestionDeClientes,ICUGestionDeServicios cUGestionDeServicios , ICUGestionDeEmpleados _cUGestionDeEmpleados)
        {
            _CUGestionDeClientes = cUGestionDeClientes;
            _CUGestionDeServicios = cUGestionDeServicios;

            _CUGestionDeEmpleados = _cUGestionDeEmpleados;
        }

            


        public IActionResult HorariosDisponibles(DtoCita dtoCita, List<int> ServicioId, int EmpleadoId)
        {
            DtoEmpleado dto = _CUGestionDeEmpleados.EncontrarEmpleado(EmpleadoId);
            List<DateTime> HorariosDisbponibles = _CUGestionDeEmpleados.ObtenerHorariosDisponibles(dto, dtoCita.FechaHora);
            ViewData["ServicioId"] = ServicioId;
            ViewData["EmpleadoId"] = EmpleadoId;
            return View(HorariosDisbponibles);

        }
        public IActionResult CrearServicio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearServicio(DtoServicio Dto)
        {
            _CUGestionDeServicios.AgregarServicio(Dto);


            return RedirectToAction("MostrarServicios");
        }

        public IActionResult MostrarServicios()
        {
            return View(_CUGestionDeServicios.TodosLosServiciosDtoServicio());
        }
        public IActionResult CrearCliente()
        {
            return View();
        }

      

        


        // POST: CrearCliente
        [HttpPost]
        public IActionResult CrearCliente(DtoCrearCliente dto)
        {
            try
            {
                // Verifica que el usuario tenga la sesión activa y el rol adecuado
                var rol = HttpContext.Session.GetString("rol");

                if (rol == null)
                {
                    // Si no hay sesión, redirige al login
                    return RedirectToAction("Login", "Usuario");
                }
                else if (rol != "Administrador")
                {
                    // Si el usuario no es administrador, muestra un mensaje de error
                    ViewBag.Mensaje = "No tienes permisos para acceder a esta funcionalidad.";
                    return View(dto);
                }

                _CUGestionDeClientes.CrearCliente(dto);
                ViewBag.Message = "Cliente creado con éxito.";
                return RedirectToAction("TodosLosClientes"); // Redirige a la acción "TodosLosClientes"
            }
            catch (ArgumentNullException ex)
            {
                ModelState.AddModelError("", "El cliente no puede ser nulo: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", "Error de validación: " + ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurrió un error inesperado: " + ex.Message);
            }

            // Si hubo errores, regresa a la vista original con los datos y mensajes de error
            return View(dto);
        }

        public IActionResult TodosLosClientes()
        {
            var clientes = _CUGestionDeClientes.TodosLosClientes();
            return View(clientes);  // Pasa la lista de clientes a la vista
        }

        public IActionResult VerCitaPorCliente()
        {
            var clientes = _CUGestionDeClientes.TodosLosClientes();
            return View(clientes);  // Pasa la lista de clientes a la vista
        }

        [HttpPost]

        public IActionResult VerCitaPorCliente(int id)
        {

            
            return View();
        }

        // GET: AdministradorController/Details/5
        public ActionResult Details(int id)
        {
            ViewData["idCli"] = id;
            return View(_CUGestionDeClientes.GetEditar(id));
        }

        // GET: AdministradorController/Edit/5
        public ActionResult Edit(int id)
        {
            
            return View(_CUGestionDeClientes.GetEditar(id));
        }



        // POST: AdministradorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DtoClienteAEditar dto)
        {
            try
            {
                _CUGestionDeClientes.PostEditar(dto);
                return View("VistaEditado"); 
            }
            catch
            {
                return View();
            }
        }


        // GET: AdministradorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_CUGestionDeClientes.GetEliminar(id));
        }

        // POST: AdministradorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DtoClienteAEditar dto)
        {
            try
            {
                _CUGestionDeClientes.PostEliminar(dto);
                return View("VistaEliminado");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult VistaEliminado()
        {
            return View();
        }  
        
        public IActionResult VistaEditado()
        {
            return View();
        }

        // GET: AdministradorController
        public ActionResult Index()
        {
            return View();
        }

      

        // GET: AdministradorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdministradorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        


       
    }
}
