using System.Text.Json.Serialization;

namespace BestShopFruit.Models
{
    /// <summary>
    /// Represents the response from a login attempt, including an authentication token and user ID.
    /// </summary>
    public class AuthResponse
    {
        
        /// <summary>
        /// Gets or sets the message .
        /// </summary>
        [JsonPropertyName("message")]
        public String Message { get; set; }
    }
}
