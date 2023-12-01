namespace BestShopFruit.View.Onboarding;

public partial class SignUpPage : ContentPage
{
	public SignUpPage(SignUpPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	private async void SignInClicked(object sender, EventArgs e)
{
    // Handle sign-in logic here
	await Shell.Current.GoToAsync($"{nameof(SignInPage)}");	
 }

}

