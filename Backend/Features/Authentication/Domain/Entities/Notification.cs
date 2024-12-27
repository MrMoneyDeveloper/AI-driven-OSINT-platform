using System;

namespace AI_driven_OSINT_platform.Backend.Features.Authentication.Domain.Entities
{
    /// <summary>
    /// Represents a notification sent to a user.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Gets or sets the unique identifier for the notification.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the message content of the notification.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the recipient's identifier or email address.
        /// </summary>
        public string Recipient { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date and time the notification was sent.
        /// </summary>
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        /// <param name="message">The message content of the notification.</param>
        /// <param name="recipient">The recipient's identifier or email address.</param>
        public Notification(string message, string recipient)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Message cannot be null or empty.", nameof(message));
            }

            if (string.IsNullOrWhiteSpace(recipient))
            {
                throw new ArgumentException("Recipient cannot be null or empty.", nameof(recipient));
            }

            Id = Guid.NewGuid();
            Message = message;
            Recipient = recipient;
            SentAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Updates the message content of the notification.
        /// </summary>
        /// <param name="newMessage">The new message content.</param>
        public void UpdateMessage(string newMessage)
        {
            if (string.IsNullOrWhiteSpace(newMessage))
            {
                throw new ArgumentException("Message cannot be null or empty.", nameof(newMessage));
            }

            Message = newMessage;
        }

        /// <summary>
        /// Updates the recipient of the notification.
        /// </summary>
        /// <param name="newRecipient">The new recipient identifier or email address.</param>
        public void UpdateRecipient(string newRecipient)
        {
            if (string.IsNullOrWhiteSpace(newRecipient))
            {
                throw new ArgumentException("Recipient cannot be null or empty.", nameof(newRecipient));
            }

            Recipient = newRecipient;
        }
    }
}
