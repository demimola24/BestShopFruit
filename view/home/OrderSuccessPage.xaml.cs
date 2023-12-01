namespace BestShopFruit.View.Home;

public partial class OrderSuccessPage : ContentPage
{
	public OrderSuccessPage()
	{
		InitializeComponent();
		BindingContext = HomePage.homePageViewModel;   
	}
}