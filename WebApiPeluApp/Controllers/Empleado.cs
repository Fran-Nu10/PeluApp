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
        public IActionResult RegistrarEmp([FromBody] DtoEmpleadoSimple dto)
        {
            try
            {
                _CUGestionDeEmpleados.RegistrarEmpleadoSimple(dto);
                
                return Ok("Empleado registrado correctamente");
            }
            catch (Exception ex)
            {
               return BadRequest("Error al registrar");
            }
        }




        // GET: Empleado/Obtener-Empleado/{id}
        [HttpGet("Obtener-Empleado/{id}")]
        public IActionResult ObtenerEmpleado(int id)
        {
            try
            {
                var empleado = _CUGestionDeEmpleados.EncontrarEmpleadoSimple(id);
                if (empleado == null)
                {
                    return new JsonResult(new
                    {
                        Message = "Empleado no encontrado"
                    })
                    {
                        StatusCode = 404
                    };
                }
                return new JsonResult(empleado, new {Mesagge="Exito"})
                {
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    Message = $"Error al obtener empleado: {ex.Message}"
                })
                {
                    StatusCode = 500
                };
            }
        }

        [HttpPut("Actualizar-Empleado/{id}")]
        public async Task<ActionResult<DtoEmpleadoSimple>> ActualizarEmpleado([FromRoute] int id, DtoEmpleadoSimple dto)
        {
            try
            {
                if (dto == null)
                {
                    return new JsonResult(new
                    {
                        Mesagge = "El objeto empleado no puede ser nulo"

                    })
                    {
                        StatusCode = 400
                    };

                }
                _CUGestionDeEmpleados.AcutualizarEmpleado(id,dto);
                return new JsonResult(new
                {
                    Mesagge = "Empleado actualizado correctamente"
                })
                {
                    StatusCode = 200
                };

            }
            catch (Exception ex) 
            {
                return new JsonResult(new{
                    Mesagge ="Error al actualizar empleado: {ex.Message}"})



            { 
                 
                StatusCode = 500
            };


            }
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

      
    }
}
