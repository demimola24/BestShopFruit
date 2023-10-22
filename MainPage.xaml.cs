namespace BestShopFruit;

public partial class MainPage : ContentPage
{
	 public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }

	private void OnNextClicked(object sender, EventArgs e)
	{
		
		Navigation.PushAsync(new SignInPage());

		//SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

