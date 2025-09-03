using DTOs.EmpleadoDTOs;
using LogicaAplicacion.InterfacesCU.ICUEmpleado;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_PeluApp.Controllers
{
    public class Empleado : Controller
    {
        private readonly ICUGestionDeEmpleados _CUGestionDeEmpleados;

        public Empleado (ICUGestionDeEmpleados cUGestionDeEmpleados)
        {
            _CUGestionDeEmpleados = cUGestionDeEmpleados;
        }

        [HttpPost("Registrar-Empleado")]
        public IActionResult RegistrarEmp(DtoEmpleado dto)
        {
            try
            {
                _CUGestionDeEmpleados.RegistrarEmpleado(dto);
                return new JsonResult("Empleado registrado correctamente");
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    Message = $"Error al registrar empleado: {ex.Message}"
                })
                {
                    StatusCode = 400
                };
            }
        }

        // GET: Empleado
        public ActionResult Index()
        {
            return View();
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleado/Create
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

        // GET: Empleado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Empleado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empleado/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
