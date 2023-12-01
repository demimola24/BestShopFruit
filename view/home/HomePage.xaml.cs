using System.Diagnostics;

namespace BestShopFruit.View.Home;

public partial class HomePage : Shell
{

     public static HomePageViewModel homePageViewModel;

    public HomePage()
    {
        InitializeComponent();
        homePageViewModel = Application.Current.Handler.MauiContext.Services.GetService<HomePageViewModel>();
        BindingContext = homePageViewModel;
        Routing.RegisterRoute(nameof(ProductDetailsPage), typeof(ProductDetailsPage));
        Routing.RegisterRoute(nameof(OrderSuccessPage), typeof(OrderSuccessPage));
        
    }
}

