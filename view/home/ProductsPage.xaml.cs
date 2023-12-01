namespace BestShopFruit.View.Home;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
        {
            InitializeComponent();
            BindingContext = HomePage.homePageViewModel;      
        }

}

