using System.Threading.Tasks;
using FunkyMunch.Data.Entities;

namespace FunkyMunch.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> GetByDisplayNameAsync(string displayName);
        Task<User> GetByEmailAddressAsync(string emailAddress);
    }
}