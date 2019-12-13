using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunkyMunch.Business.Dto;
using FunkyMunch.Business.Exceptions;
using FunkyMunch.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FunkyMunch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IAuthenticationService authenticationService, ILogger<LoginController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        /// <summary>
        ///     Login
        /// </summary>
        /// <param name="dto"><see cref="LoginDto"/></param>
        /// <returns><see cref="TokenDto"/></returns>
        [HttpPost]
        [Route("")]        
        public async Task<IActionResult> Post([FromBody] LoginDto dto) 
        {
            try
            {
                var result = await _authenticationService.LoginAsync(dto);
                return Ok(result);
            }
            catch(FluentValidation.ValidationException valEx)
            {
                _logger.LogError(valEx, "Validation Exception");
                return BadRequest();
            }
            catch(InvalidCredentialsException credEx)
            {
                _logger.LogError(credEx, "Invalid Credentials Exception");
                return Unauthorized();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "General Exception");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}