using LogicaAplicacion.InterfacesCU.ICUCliente;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_PeluApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cliente : ControllerBase
    {
        private ICUGestionDeClientes _cu;

        public Cliente(ICUGestionDeClientes cUGestionDeClientes)
        {
            this._cu = cUGestionDeClientes;
        }



        // POST /api/clientes
        [HttpPost]
        public async Task<ActionResult<DtoCrearCliente>> Crear([FromBody] DtoCrearCliente dto, CancellationToken ct)
        {
            if (dto is null) return BadRequest("Body requerido.");

            try
            {
                var nuevoId = await _cu.CrearClienteAPI(dto, ct);
                var creado = await _cu.FindByIdAsync(nuevoId, ct);
                return CreatedAtAction(nameof(Get), new { id = nuevoId }, creado);
            }
            catch (Exception ex) // si tu CU valida email único
            {
                return Conflict(new { message = ex.Message });
            }
            //catch (Exception ex)
            //{
            //    return BadRequest(new { message = ex.Message, errors = ex.Errors });
            //}
        }

        // GET api/<Clientes>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/<Clientes>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Clientes>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
