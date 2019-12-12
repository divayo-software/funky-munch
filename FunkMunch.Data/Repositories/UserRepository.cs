using FunkyMunch.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FunkyMunch.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FunkyMunchDbContext _dbContext;

        public UserRepository(FunkyMunchDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        ///     Create a new user
        /// </summary>
        /// <param name="user">User to create</param>
        /// <returns>User with metadata and id</returns>
        public async Task<User> CreateAsync(User user)
        {
            user.CreatedAt = DateTime.Now;
            user.CreatedBy = "System";
            
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        /// <summary>
        ///     Get user by email address
        /// </summary>
        /// <param name="emailAddress">email address to search for</param>
        /// <returns><see cref="User"/> or null</returns>
        public async Task<User> GetByEmailAddressAsync(string emailAddress)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.EmailAddress.ToLower().Equals(emailAddress.ToLower()));
        }

        /// <summary>
        ///     Get user by display name
        /// </summary>
        /// <param name="displayName">display name to search for</param>
        /// <returns><see cref="User"/> or null</returns>
        public async Task<User> GetByDisplayNameAsync(string displayName)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.DisplayName.ToLower().Equals(displayName.ToLower()));
        }
    }
}
