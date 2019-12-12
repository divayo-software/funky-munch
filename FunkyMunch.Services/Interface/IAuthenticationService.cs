using System.Threading.Tasks;
using FunkyMunch.Business.Dto;
using FunkyMunch.Business.Exceptions;

namespace FunkyMunch.Services
{
    public interface IAuthenticationService
    {
        /// <summary>
        ///     Login User
        /// </summary>
        /// <param name="dto"><see cref="LoginDto"/></param>
        /// <returns><see cref="TokenDto"/></returns>
        /// <exception cref="FluentValidation.ValidationException">If the dto does not pass validation.</exception>
        /// <exception cref="InvalidCredentialsException">If credentials are incorrect.</exception>
        Task<TokenDto> LoginAsync(LoginDto dto);

        /// <summary>
        ///     Register a new user
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="FluentValidation.ValidationException">If the dto does not pass validation.</exception>
        /// <exception cref="DuplicateEmailAddressException">If the email address is already registered.</exception>
        /// <exception cref="DuplicateDisplayNameException">If the display name is alreay registered.</exception>
        Task<bool> RegisterAsync(RegistrationDto dto);
    }
}