namespace BestShopFruit.View.Home;

public partial class OrderedPage : ContentPage
{
	public OrderedPage()
        {
            InitializeComponent(); 
            BindingContext = HomePage.homePageViewModel;      
        }

}

