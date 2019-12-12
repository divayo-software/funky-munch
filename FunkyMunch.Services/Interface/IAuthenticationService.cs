using System.Threading.Tasks;
using FunkyMunch.Business.Dto;

namespace FunkyMunch.Services
{
    public interface IAuthenticationService
    {
        Task<TokenDto> LoginAsync(LoginDto dto);
        Task<bool> RegisterAsync(RegistrationDto dto);
    }
}