using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BZPAY_BE.BussinessLogic.Implementations;
using BZPAY_BE.BussinessLogic.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BZPAY_BE.Controllers.Events
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _service;

        public EventosController(IEventoService service) => _service = service;

        /// <summary>
        /// StartSessionAsync
        /// </summary>
        /// <param>loginRequest</param>
        /// <returns>AspnetUserDo</returns>
    
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(UserDo),StatusCodes.Status200OK)]
        //public async Task<ActionResult<EventoDo>> GetAllEventosAsync()
        //{
        //    EventoDo result  = (EventoDo)await _service.GetAllEventosAsync();
        //    return (result is null) ? NotFound() : Ok(result);  
        //}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<EventoDo>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EventoDo>>> GetAllEventosAsync()
        {
            var eventos = await _service.GetAllEventosAsync();
            if (eventos == null)
            {
                return NotFound();
            }
            return Ok(eventos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(UserDo), StatusCodes.Status200OK)]
        public async Task<ActionResult<EventoDo>> GetEventoByIdAsync([FromBody] int id)
        {
            EventoDo result = await _service.GetEventoByIdAsync(id);
            return (result is null) ? NotFound() : Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(List<EventoDo>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DetalleEventoDo>>> GetAllDetalleEventosAsync()
        {
            var detalleEventos = await _service.GetAllDetalleEventosAsync();
            if (detalleEventos == null)
            {
                return NotFound();
            }
            return Ok(detalleEventos);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(UserDo), StatusCodes.Status200OK)]
        public async Task<ActionResult<DetalleEventoDo>> GetDetalleEventosByIdAsync([FromBody] int id)
        {
            DetalleEventoDo result = await _service.GetDetalleEventosByIdAsync(id);
            return (result is null) ? NotFound() : Ok(result);
        }

    }
}