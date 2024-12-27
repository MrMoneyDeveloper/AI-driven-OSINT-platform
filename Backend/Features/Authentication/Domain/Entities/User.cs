using System;

namespace AI_driven_OSINT_platform.Backend.Features.Authentication.Domain.Entities
{
    /// <summary>
    /// Represents a user within the authentication system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the username for the user.
        /// </summary>
        public string Username { get; private set; } = string.Empty;

        /// <summary>
        /// Gets or sets the hashed password for the user.
        /// </summary>
        public string PasswordHash { get; private set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string Email { get; private set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time the user was created.
        /// </summary>
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="username">The username for the user.</param>
        /// <param name="passwordHash">The hashed password for the user.</param>
        /// <param name="email">The email address of the user.</param>
        public User(string username, string passwordHash, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("PasswordHash cannot be null or empty.", nameof(passwordHash));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));

            Id = Guid.NewGuid();
            Username = username;
            PasswordHash = passwordHash;
            Email = email;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Updates the user's email address.
        /// </summary>
        /// <param name="newEmail">The new email address.</param>
        public void UpdateEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
                throw new ArgumentException("Email cannot be null or empty.", nameof(newEmail));

            Email = newEmail;
        }

        /// <summary>
        /// Updates the user's password hash.
        /// </summary>
        /// <param name="newPasswordHash">The new hashed password.</param>
        public void UpdatePassword(string newPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(newPasswordHash))
                throw new ArgumentException("PasswordHash cannot be null or empty.", nameof(newPasswordHash));

            PasswordHash = newPasswordHash;
        }
    }
}
