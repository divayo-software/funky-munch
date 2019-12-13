using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunkyMunch.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FunkyMunch.API.Controllers
{
    [Route("api/token_refresh")]
    [ApiController]
    public class TokenRefreshController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<LoginController> _logger;

        public TokenRefreshController(IAuthenticationService authenticationService, ILogger<LoginController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get([FromQuery] string token)
        {
            throw new NotImplementedException();
        }
    }
}