namespace BestShopFruit;

public partial class HomePage : ContentPage
{

	 private readonly HttpClient _httpClient;


	public HomePage(HomePageViewModel homePageViewModel)
        {
            InitializeComponent();
            BindingContext = homePageViewModel;
        }

}

