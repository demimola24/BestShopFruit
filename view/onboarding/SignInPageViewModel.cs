using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestShopFruit
{
    public partial class SignInPageViewModel : ObservableObject
    {
         private readonly HttpClient _httpClient;
         public ObservableCollection<Boolean> loginStatus { get; set; } = new();

          public SignInPageViewModel(){         
            _httpClient = new HttpClient();
         }

         public async Task RefreshDataAsync(String username, String password){    

            Uri uri = new Uri(string.Format("https://fruitappwp.azurewebsites.net/api/users/login", string.Empty));
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    loginStatus.Add(true);
                    
                }
            }
            catch (Exception ex)
            {
                loginStatus.Add(false);            
            }
    
      }

    }
    
}
