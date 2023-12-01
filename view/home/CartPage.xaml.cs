namespace BestShopFruit.View.Home;

public partial class CartPage : ContentPage
{
	public CartPage()
        {
            InitializeComponent(); 
            BindingContext = HomePage.homePageViewModel;      
        }

}

