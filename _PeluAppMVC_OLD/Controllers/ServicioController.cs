using DTOs.ServicioDTOs;
using LogicaAplicacion.InterfacesCU.ICUCita;
using LogicaAplicacion.InterfacesCU.ICUCliente;
using LogicaAplicacion.InterfacesCU.ICUEmpleado;
using LogicaAplicacion.InterfacesCU.ICUServicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PeluAppMVC.Controllers
{
    public class ServicioController : Controller
    {
        private  ICUGestionDeServicios _RepoServicio;

        public ServicioController(ICUGestionDeServicios repoServicio)
        {
            _RepoServicio = repoServicio;
        }
        // GET: Servicio/Details/5
        public ActionResult Details(int id)
        {
            return View(_RepoServicio.GetEditar(id));
        }

        // GET: Servicio/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_RepoServicio.GetEditar(id));
        }

        // POST: Servicio/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DtoServicio dto)
        {
            try
            {
                _RepoServicio.PostEditar(dto);
                return View("VistaEditado");
            }
            catch
            {
                return View();
            }
        }

        // GET: Servicio/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_RepoServicio.GetEliminar(id));
        }

        // POST: Servicio/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DtoServicio dto)
        {
            try
            {
                _RepoServicio.PostEliminar(dto);
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
