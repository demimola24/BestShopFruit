using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BestShopFruit.Models;
using BestShopFruit.View.Home;
using BestShopFruit.Services;
using System.Windows.Input;

namespace BestShopFruit.View.Onboarding
{
    public partial class SignUpPageViewModel : BaseViewModel
    {
        private readonly AppService _authService;
        public ICommand RegisterCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpPageViewModel"/> class.
        /// </summary>
        /// <param name="authService">The authentication service.</param>
        public SignUpPageViewModel(AppService authService)
        {
            _authService = authService;
            RegisterCommand = new Command(async () => await Register(username, password));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpPageViewModel"/> class. This empty constructor is used for design-time data.
        /// </summary>
        public SignUpPageViewModel(){}

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

    
        public async Task Register(string Username, string Password)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                Debug.WriteLine($"Register Details. Log: {Username} {Password}");   
                response = await _authService.RegisterAsync(Username, Password);

                App.Current.MainPage = new HomePage();
                //await Shell.Current.GoToAsync($"{nameof(HomePage)}");	
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Register Error. Log: {ex}");   
                await Application.Current.MainPage.DisplayAlert("Error!", "You have entered invalid values", "OK");                
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
