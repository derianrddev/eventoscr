using BZPAY_BE.BussinessLogic.Implementations;
using BZPAY_BE.BussinessLogic.Interfaces;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using BZPAY_BE.Services.Implementations;
using BZPAY_BE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;

namespace BZPAY_BE.Controllers.events
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradasController : ControllerBase
    {
        private readonly IEntradaService _service;
        private readonly IEventoService _eventoService;

        public EntradasController(IEntradaService service) => _service = service;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<EntradaDo>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EntradaDo>>> CreateEntradaAsync([Bind("Disponibles,TipoAsiento,Precio,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,Active,IdEvento")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entradaDo = await _service.CreateEntradaAsync(entrada);
                    //return RedirectToAction(nameof(Index));
                    return Ok(entradaDo);
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException is MySqlException mySqlEx && mySqlEx.Number == 1062) // 1062 es el número de error de MySQL para entradas duplicadas
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe una entrada con este tipo de asiento para este evento.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Ocurrió un error al guardar la entrada.");
                    }
                }
            }
            return Ok(entrada);

        }

    }
}
