
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using BestShopFruit.Models;

namespace BestShopFruit.Services
{
    /// <summary>
    /// This class is responsible for authenticating the user and storing the token and userId in secure storage.
    /// </summary>
    public class AppService : BaseService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppService"/> class.
        /// </summary>
        public AppService()
        {
        }

    

        /// <summary>
        /// Register the user.    
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A task of type <see cref="AuthResponse"/>.</returns>
        public async Task<AuthResponse> RegisterAsync(string username, string password)
        {
            var request = new LoginRequest
            {
                Username = username,
                Password = password,
            };

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
    

            var response = await _httpClient.PostAsync("api/users/register", content);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            Debug.WriteLine($"Register Response: {responseContent}");   

            return JsonSerializer.Deserialize<AuthResponse>(responseContent);                
        }


        /// <summary>
        /// Logs the user in.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A task of type <see cref="AuthResponse"/>.</returns>
        public async Task<AuthResponse> LoginAsync(string username, string password)
        {
            var request = new LoginRequest
            {
                Username = username,
                Password = password,
            };

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/users/login", content);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<AuthResponse>(responseContent);                    
        }


        public async Task<IEnumerable<FruitModel>> GetFruitsAsync() 
        {        
            return await GetAsync<IEnumerable<FruitModel>>("fruits");
        }
    }
}
