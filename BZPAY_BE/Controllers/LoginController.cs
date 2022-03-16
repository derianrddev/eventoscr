using BZPAY_BE.models;
using Microsoft.AspNetCore.Mvc;

namespace BZPAY_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public LoginResponse IniciarSesion([FromBody] Login login)
        {
            var response = new LoginResponse();

            response.Result = true;
            response.User = login;
            if (login.username == "Lesmes" && login.password == "daf30309483f82484d66608e7d8492c0")
            {
                response.Result = true;
                response.User = login;
            }
            else
            {
                response.Result = false;
                response.User = null;
            }

            return response;
        }

    }
}