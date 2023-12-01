using System.Text.Json.Serialization;

namespace BestShopFruit.Models
{
    /// <summary>
    /// Represents a request for user login with username and password.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Gets or sets the username for login.
        /// </summary>
        [JsonPropertyName("Email")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password for login.
        /// </summary>
        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}
