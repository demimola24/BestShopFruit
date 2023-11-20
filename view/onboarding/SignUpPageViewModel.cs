using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestShopFruit
{
    public partial class SignUpPageViewModel : ObservableObject
    {
          private readonly HttpClient _httpClient;
         public ObservableCollection<Boolean> registrationStatus { get; set; } = new();

          public SignUpPageViewModel(){         
            _httpClient = new HttpClient();
         }

         public async Task RefreshDataAsync(String username, String password){    

            Uri uri = new Uri(string.Format("https://fruitappwp.azurewebsites.net/api/users/register", string.Empty));
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    registrationStatus.Add(true);
                    
                }
            }
            catch (Exception ex)
            {
                registrationStatus.Add(false);            
            }
    
      }
    }
}
