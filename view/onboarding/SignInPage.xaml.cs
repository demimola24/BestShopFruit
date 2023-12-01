namespace BestShopFruit.View.Onboarding;

public partial class SignInPage : ContentPage
{
	public SignInPage(SignInPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

private async void SignUpClicked(object sender, EventArgs e)
{
    // Handle sign-in logic here
	await Shell.Current.GoToAsync($"{nameof(SignUpPage)}");	 
 }

}

