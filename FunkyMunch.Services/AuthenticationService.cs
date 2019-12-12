using FunkyMunch.Business.Dto;
using FunkyMunch.Business.Exceptions;
using FunkyMunch.Business.Validators;
using FunkyMunch.Data.Entities;
using FunkyMunch.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FunkyMunch.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher<User> _pwdHasher;

        public AuthenticationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _pwdHasher = new PasswordHasher<User>();
        }

        /// <summary>
        ///     Register a new user
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="FluentValidation.ValidationException">If the dto does not pass validation.</exception>
        /// <exception cref="DuplicateEmailAddressException">If the email address is already registered.</exception>
        /// <exception cref="DuplicateDisplayNameException">If the display name is alreay registered.</exception>
        public async Task<bool> RegisterAsync(RegistrationDto dto)
        {
            var validator = new RegistrationDtoValidator();
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            var byEmail = await _userRepository.GetByEmailAddressAsync(dto.EmailAddress);

            if (byEmail != null)
            {
                throw new DuplicateEmailAddressException();
            }

            var byDisplayName = await _userRepository.GetByDisplayNameAsync(dto.DisplayName);

            if (byDisplayName != null)
            {
                throw new DuplicateDisplayNameException();
            }

            var newUser = new User
            {
                DisplayName = dto.DisplayName,
                EmailAddress = dto.EmailAddress
            };

            var hashedPassword = _pwdHasher.HashPassword(newUser, dto.Password);

            await _userRepository.CreateAsync(newUser);

            return true;
        }

        /// <summary>
        ///     Login User
        /// </summary>
        /// <param name="dto"><see cref="LoginDto"/></param>
        /// <returns><see cref="TokenDto"/></returns>
        /// <exception cref="FluentValidation.ValidationException">If the dto does not pass validation.</exception>
        /// <exception cref="InvalidCredentialsException">If credentials are incorrect.</exception>
        public async Task<TokenDto> LoginAsync(LoginDto dto)
        {
            var validator = new LoginDtoValidator();
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }

            var byDisplayName = await _userRepository.GetByDisplayNameAsync(dto.DisplayName);

            if (byDisplayName == null)
            {
                throw new InvalidCredentialsException();
            }

            var pwdResult = _pwdHasher.VerifyHashedPassword(byDisplayName, byDisplayName.Password, dto.Password);

            if (pwdResult == PasswordVerificationResult.Failed)
            {
                throw new InvalidCredentialsException();
            }

            var token = CreateToken(byDisplayName);

            return new TokenDto
            {
                Token = token
            };
        }

        private string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this_is_a_placeholder");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
