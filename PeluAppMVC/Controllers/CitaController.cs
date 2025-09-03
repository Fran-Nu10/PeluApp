using DTOs.CitaDTOs;
using LogicaAplicacion.InterfacesCU.ICUCita;
using LogicaAplicacion.InterfacesCU.ICUCliente;
using LogicaAplicacion.InterfacesCU.ICUEmpleado;
using LogicaAplicacion.InterfacesCU.ICUServicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PeluAppMVC.Controllers
{
    public class CitaController : Controller
    {

        private ICUCitas _CUCitas;
        private ICUAgendarCitas _CUAgendarCitas;
        private ICUGestionDeClientes _CUGestionClientes;
        private ICUGestionDeServicios _CUGestionDeServicios;
        private ICUGestionDeEmpleados _CUGestionDeEmpleados;
        


        public CitaController(ICUCitas cUCitas, ICUAgendarCitas agendarCitas, ICUGestionDeClientes gestionDeClientes, ICUGestionDeServicios gestion,ICUGestionDeEmpleados gestionE)
        {
            _CUCitas = cUCitas;
            _CUAgendarCitas = agendarCitas;
            _CUGestionClientes = gestionDeClientes;
            _CUGestionDeServicios = gestion;
            _CUGestionDeEmpleados = gestionE;
        }



        public IActionResult RegistrarCita()
        {          
            var Empleados = _CUGestionDeEmpleados.TodosLosEmpleados();
            var Servicios =_CUGestionDeServicios.TodosLosServicios();

            // Pasar las listas directamente a ViewData
            ViewData["Empleados"] = Empleados;
            ViewData["Servicios"] = Servicios;

            return View();
        }



       
        public IActionResult RegistrarCitaFinal(DtoCita dtoCita, int ServicioId, int EmpleadoId)
        {
            int? id = HttpContext.Session.GetInt32("LogueadoId");
            _CUAgendarCitas.AgendarCita(dtoCita, id,EmpleadoId, ServicioId);
            return RedirectToAction("ObtenerHistorialDeCitas");  
             }



        public IActionResult VistaVerCitasCliente()
        {
            return View(_CUGestionClientes.TodosLosClientes());
        }

        public IActionResult CitasPasadasPorCliente()
        {
            var Id = HttpContext.Session.GetInt32("IdDeCliente");
           

            return View(_CUCitas.HistorialCitasPorCliente(Id));
        }


        public IActionResult ObtenerHistorialDeCitas()
        {
            return View(_CUCitas.HisorialDeCitas());
        }

        // GET: CitaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cita/Details/5
        public ActionResult Details(int id)
        {
            ViewData["idCita"] = id;
            return View(_CUCitas.GetEditar(id));
        }

        // GET: Cita/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_CUCitas.GetEditar(id));
        }

        // POST: Cita/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DtoCita dto)
        {
            try
            {
                _CUCitas.PostEditar(dto);
                return View("VistaEditado");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cita/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_CUCitas.GetEliminar(id));
        }

        // POST: Cita/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DtoCita dto)
        {
            try
            {
                _CUCitas.PostEliminar(dto);
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
    }
}
