using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BZPAY_BE.BussinessLogic.auth.ServiceInterface;
using System.Collections.Generic;
using System.Threading.Tasks;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Models;
using System.Linq;

namespace BZPAY_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AspnetUserController : ControllerBase
    {
        private readonly IAspnetUserService _service;

        public AspnetUserController(IAspnetUserService service) => _service = service;

        /// <summary>
        /// IniciarSesionAsync
        /// </summary>
        /// <param>login"</param>
        /// <returns>LoginResponse</returns>
        [HttpPost]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(AspnetUserDo),StatusCodes.Status200OK)]
        public async Task<ActionResult<AspnetUserDo>> StartSessionAsync([FromBody] LoginRequest login)
        {
            AspnetUserDo result  = await _service.StartSessionAsync(login);
            return (result is null) ? NotFound() : Ok(result);  
        }

    }
}