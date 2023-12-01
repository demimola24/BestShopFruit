namespace BestShopFruit.View.Home;

public partial class ProductDetailsPage : ContentPage
{
	public ProductDetailsPage()
	{
		InitializeComponent();
		BindingContext = HomePage.homePageViewModel;   
	}
}