using AI_driven_OSINT_platform.Backend.Features.Authentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace AI_driven_OSINT_platform.Backend.Features.Authentication.Infrastructure.Persistence
{
    /// <summary>
    /// Repository for managing user-related database operations.
    /// </summary>
    public class UserRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The database context for accessing user data.</param>
        public UserRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">The user entity to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User entity cannot be null.");
            }

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception (logging logic should be implemented).
                throw new InvalidOperationException("An error occurred while adding the user to the database.", ex);
            }
        }

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>The user entity if found; otherwise, <c>null</c>.</returns>
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            }

            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            }
            catch (Exception ex)
            {
                // Log the exception (logging logic should be implemented).
                throw new InvalidOperationException("An error occurred while retrieving the user from the database.", ex);
            }
        }
    }
}
