namespace BestShopFruit;

public partial class SignInPage : ContentPage
{


	public SignInPage()
	{
		InitializeComponent();
	}

	private void SignUpClicked(object sender, EventArgs e)
{
	 Navigation.PushAsync(new SignUpPage());
    // Handle sign-in logic here
}
}

