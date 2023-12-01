using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BestShopFruit.Models;
using BestShopFruit.Services;
using System.Windows.Input;
using BestShopFruit.View.Home;

namespace BestShopFruit.View.Onboarding
{
    public partial class SignInPageViewModel : BaseViewModel
    {
        private readonly AppService _authService;
         public ICommand LoginCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignInPageViewModel"/> class.
        /// </summary>
        /// <param name="authService">The authentication service.</param>
        public SignInPageViewModel(AppService authService)
        {
            _authService = authService;
             LoginCommand = new Command(async () => await Login(username, password));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignInPageViewModel"/> class. This empty constructor is used for design-time data.
        /// </summary>
        public SignInPageViewModel(){}

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [ObservableProperty]
        string username;

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [ObservableProperty]
        string password;

        /// <summary>
        /// Gets or sets a value indicating whether the password is visible.
        /// </summary>
        [ObservableProperty]
        bool isPasswordVisible;

        private AuthResponse response = new AuthResponse();

    
        public async Task Login(string Username, string Password)
        {
            Debug.WriteLine("Login Called.");
            
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                response = await _authService.LoginAsync(Username, Password);

                App.Current.MainPage = new HomePage();
                //await App.Current.MainPage.Navigation.PushAsync(new HomePage());

                //await Shell.Current.GoToAsync($"{nameof(HomePage)}");	
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Login Error. {ex}");
                 await Application.Current.MainPage.DisplayAlert("Error!", "You have entered invalid credentials", "OK");                
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Toggles the password visibility.
        /// </summary>
        [RelayCommand]
        public void TogglePasswordVisibility()
        {
            this.IsPasswordVisible = !this.IsPasswordVisible;
        }

    }
    
}
