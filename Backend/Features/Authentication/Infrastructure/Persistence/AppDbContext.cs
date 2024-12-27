using Microsoft.EntityFrameworkCore;
using AI_driven_OSINT_platform.Backend.Features.Authentication.Domain.Entities;

namespace AI_driven_OSINT_platform.Backend.Features.Authentication.Infrastructure.Persistence
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the DbSet for user entities.
        /// </summary>
        public DbSet<User> Users { get; set; } = null!;

        /// <summary>
        /// Gets or sets the DbSet for notification entities.
        /// </summary>
        public DbSet<Notification> Notifications { get; set; } = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to configure the database context.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Configures the model using the Fluent API.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id); // Set the primary key
                entity.Property(u => u.Username)
                      .IsRequired()
                      .HasMaxLength(50); // Enforce required and max length for Username
                entity.HasIndex(u => u.Username).IsUnique(); // Ensure Username is unique

                entity.Property(u => u.Email)
                      .IsRequired()
                      .HasMaxLength(100); // Enforce required and max length for Email

                entity.Property(u => u.PasswordHash)
                      .IsRequired(); // Enforce required for PasswordHash

                entity.Property(u => u.CreatedAt)
                      .IsRequired(); // Enforce required for CreatedAt
            });

            // Configure Notification entity
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(n => n.Id); // Set the primary key
                entity.Property(n => n.Message)
                      .IsRequired()
                      .HasMaxLength(500); // Enforce required and max length for Message
                entity.Property(n => n.Recipient)
                      .IsRequired()
                      .HasMaxLength(100); // Enforce required and max length for Recipient
                entity.Property(n => n.SentAt)
                      .IsRequired(); // Enforce required for SentAt
            });
        }
    }
}
