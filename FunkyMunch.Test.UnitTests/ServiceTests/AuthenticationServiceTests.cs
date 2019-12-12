using FunkyMunch.Business.Dto;
using FunkyMunch.Data.Entities;
using FunkyMunch.Data.Repositories;
using FunkyMunch.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace FunkyMunch.Test.UnitTests.ServiceTests
{
    public class AuthenticationServiceTests
    {
        private IAuthenticationService _authService;

        [Fact]
        public async Task Registration_Success()
        {
            var mockedRepo = new Mock<IUserRepository>();
            var dto = new RegistrationDto();

            mockedRepo.Setup(x => x.GetByEmailAddressAsync(It.IsAny<string>())).Returns(Task.FromResult<User>(null));
            mockedRepo.Setup(x => x.GetByDisplayNameAsync(It.IsAny<string>())).Returns(Task.FromResult<User>(null));

            dto.DisplayName = "New_User";
            dto.EmailAddress = "new_user@unit.test";
            dto.Password = "password";

            _authService = new AuthenticationService(mockedRepo.Object);

            var result = await _authService.RegisterAsync(dto);

            Assert.True(result);
        }

        [Fact]
        public async Task Login_Success()
        {
            var mockedRepo = new Mock<IUserRepository>();
            var dto = new LoginDto();

            mockedRepo.Setup(x => x.GetByDisplayNameAsync(It.IsAny<string>())).Returns(Task.FromResult(TestHelpers.UserRepositoryHelpers.GetTestUserWithId(1)));
            dto.DisplayName = "Unit_Tester";
            dto.Password = "password";

            _authService = new AuthenticationService(mockedRepo.Object);

            var result = await _authService.LoginAsync(dto);

            Assert.NotEmpty(result.Token);
        }
    }
}
