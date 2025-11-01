using DTOs.CitaDTOs;
using DTOs.ClienteDTOs;
using DTOs.UsuarioDTOs;
using LogicaAplicacion.InterfacesCU.ICUCita;
using LogicaAplicacion.InterfacesCU.ICUCliente;
using LogicaAplicacion.InterfacesCU.ICUUsuario;
using Microsoft.AspNetCore.Mvc;

namespace PeluAppMVC.Controllers
{
    public class UsuarioController : Controller
    {
        private ICURegistrarCliente _CURegistroCli;
        private ICULogin _CuLogin;
        private ICUGestionDeClientes _CUGestionDeClientes;
        private ICUGestionDeUsuarios _CUGestionDeUsuarios;
        private ICUCitas _CUCitas;


        public UsuarioController(ICULogin cULogin,ICURegistrarCliente cURegistrarCliente,ICUGestionDeClientes cUGestionDeClientes,ICUGestionDeUsuarios a,ICUCitas c)
        {
            _CuLogin = cULogin;
            _CURegistroCli = cURegistrarCliente;
            _CUGestionDeClientes= cUGestionDeClientes;
            _CUGestionDeUsuarios = a;
            _CUCitas = c;
        }


        public IActionResult PerfilDeUsuario()
        {
           int? IdUsu = HttpContext.Session.GetInt32("LogueadoId");
            DtoUsuario dto = _CUGestionDeUsuarios.EncontrarUsuario(IdUsu);
            DtoClienteAEditar cliente = _CUGestionDeClientes.EncontrarCliente(dto.Email);

          List<DtoHistorialDeCitas >d = _CUCitas.HistorialCitasPorCliente(cliente.Id);
                ViewData["Citas"]  = d;

            return View(_CUGestionDeUsuarios.MostrarPerfilDeUsuario(IdUsu));
        }

        public IActionResult RegistrarCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarCliente(DtoRegistroUsuario dto)
        {
            _CURegistroCli.RegistroCliente(dto);
            return View("BienvenidaUsuario");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logeado(DtoLogin dto)
        {
            DtoLogin usuBuscado = _CuLogin.Login(dto);
            try
            {
                if (usuBuscado != null)
                {
                    HttpContext.Session.SetString("rol", usuBuscado.Rol);
                    HttpContext.Session.SetInt32("LogueadoId", usuBuscado.Id);
                    HttpContext.Session.SetString("EmailLogin", usuBuscado.Email);




                    if (usuBuscado.Rol== "Administrador")
                    {
                        return View("BienvenidaAdministrador");
                    }
                    else if (usuBuscado.Rol == "Empleado")
                    {
                        return View("BienvenidaEmpleado");
                    }
                    else if (usuBuscado.Rol== "Cliente")
                    {
                        DtoClienteAEditar dtoo = _CUGestionDeClientes.EncontrarCliente(usuBuscado.Email);
                         HttpContext.Session.SetInt32("IdDeCliente", dtoo.Id);

                        return View("BienvenidaCliente");
                    }
                    else if (usuBuscado.Rol.Trim() == "Usuario")
                    {
                        return View("BienvenidaUsuario");
                    }

                }
                else
                {
                    ViewBag.Mensaje = "Datos incorrectos";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return View();
        }

        public IActionResult BienvenidaUsuario()
        {
            return View();
        }

        public IActionResult BienvenidaEmpleado()
        {
            return View();
        }

        public IActionResult BienvenidaCliente()
        {
            return View();
        }

        public IActionResult BienvenidaAdministrador()
        {
            return View();
        }


        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
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

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
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

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
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
