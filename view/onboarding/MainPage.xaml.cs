namespace BestShopFruit.View.Onboarding;

public partial class MainPage : ContentPage
{
	 public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }


/* Unmerged change from project 'BestShopFruit (net7.0-ios)'
Before:
	private void OnNextClicked(object sender, EventArgs e)
After:
	private async Task OnNextClickedAsync(object sender, EventArgs e)
*/
	private async void OnNextClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync($"{nameof(SignInPage)}");
		//Navigation.PushAsync(new SignInPage());

		//SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

