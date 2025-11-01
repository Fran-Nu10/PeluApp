using DTOs.CitaDTOs;
using DTOs.UsuarioDTOs;
using LogicaAplicacion.InterfacesCU.ICUCliente;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PeluAppMVC.Controllers
{
    public class ClienteController : Controller
    {
        private ICURegistrarCliente _CURegistroCli;
        private ICUMostrarServicios _CUMostrarServicios;

        public ClienteController(ICURegistrarCliente CURegistroCli,ICUMostrarServicios cUMostrarServicios)
        {
            _CURegistroCli = CURegistroCli;
            _CUMostrarServicios = cUMostrarServicios;
        }

        //public IActionResult RegistrarCliente()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult RegistrarCliente(DtoRegistroUsuario dto)
        //{
        //    _CURegistroCli.RegistroCliente(dto);
        //    return View();
        //}



        public IActionResult MostrarServiciosDeClientes()
        {
            int IdCliente = (int)HttpContext.Session.GetInt32("IdDeCliente");


         
            return View(_CUMostrarServicios.MostrarServiciosPorCliente(IdCliente));
        }

        // GET: ClienteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
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

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteController/Edit/5
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

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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
