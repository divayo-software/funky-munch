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
    public class RegisterController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(IAuthenticationService authenticationService, ILogger<RegisterController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        /// <summary>
        ///     Login
        /// </summary>
        /// <param name="dto"><see cref="RegistrationDto"/></param>
        /// <returns><see cref="OkResult"/></returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post([FromBody] RegistrationDto dto)
        {
            try
            {
                var result = await _authenticationService.RegisterAsync(dto);

                if (result)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (FluentValidation.ValidationException valEx)
            {
                _logger.LogError(valEx, "Validation Exception");
                return BadRequest();
            }
            catch (DuplicateDisplayNameException nameEx)
            {
                _logger.LogError(nameEx, "Duplicate DisplayName Exception");
                return BadRequest();
            }
            catch (DuplicateEmailAddressException emailEx)
            {
                _logger.LogError(emailEx, "Duplicate EmailAddress Exception");
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "General Exception");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}