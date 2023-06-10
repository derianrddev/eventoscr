using BZPAY_BE.BussinessLogic.Implementations;
using BZPAY_BE.BussinessLogic.Interfaces;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
using BZPAY_BE.Models.Entities;
using BZPAY_BE.Services.Implementations;
using BZPAY_BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;

namespace BZPAY_BE.Controllers.Events
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EntradasController : ControllerBase
    {
        private readonly IEntradaService _service;

        public EntradasController(IEntradaService service) => _service = service;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<EntradaDo>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EntradaDo>>> GetAllEntradasAsync()
        {
            var entradas = await _service.GetAllEntradasAsync();
            if (entradas == null)
            {
                return NotFound();
            }
            return Ok(entradas);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<EntradaDo>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EntradaDo>>> CreateEntradaAsync(Entrada entrada, string userId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entradaDo = await _service.CreateEntradaAsync(entrada, userId);
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
