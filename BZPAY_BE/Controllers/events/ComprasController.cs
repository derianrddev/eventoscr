using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
using BZPAY_BE.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BZPAY_BE.Controllers.Events
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ComprasController : ControllerBase
    {
        private readonly IEntradaService _entradaService;
        private readonly ICompraService _compraService;

        public ComprasController(IEntradaService entradaService, ICompraService compraService){
            _entradaService = entradaService;
            _compraService = compraService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<CompraDo>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CompraDo>>> GetCompraByIdClienteAsync(string id)
        {
            var compras = await _compraService.GetCompraByIdClienteAsync(id);
            if (compras == null)
            {
                return NotFound();
            }
            return Ok(compras);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CompraDo), StatusCodes.Status200OK)]
        public async Task<ActionResult<CompraDo>> CreateCompraAsync(int cantidad,int idEntrada, string userId)
        {
            var error = false;

            // Validación 1: Cantidad de entradas a comprar
            var entrada = await _entradaService.GetEntradaByIdAsync(idEntrada);
            if (entrada == null)
            {
                ModelState.AddModelError("IdEntrada", "La entrada no existe.");
                error = true;
            }
            else if (cantidad > entrada.Disponibles)
            {
                ModelState.AddModelError("Cantidad", "No hay suficientes entradas disponibles para realizar la compra.");
                error = true;
            }

            if (error == false)
            {
                var compra = await _compraService.CreateCompraAsync(cantidad, idEntrada, userId);

                if (entrada != null)
                {
                    entrada.Disponibles -= cantidad;
                    await _entradaService.UpdateEntradaAsync(entrada, userId);
                }

                return Ok(compra);
            }

            return NotFound();
        }
    }
}
