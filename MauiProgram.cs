using Microsoft.Extensions.Logging;
using BestShopFruit.Services;
using BestShopFruit.View.Onboarding;
using BestShopFruit.View.Home;
using CommunityToolkit.Maui;

namespace BestShopFruit;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}).UseMauiCommunityToolkit();
			 builder.Services.AddSingleton<BaseService>();
			 builder.Services.AddSingleton<AppService>();

			 builder.Services.AddSingleton<MainPageViewModel>();
             builder.Services.AddSingleton<MainPage>();

             builder.Services.AddSingleton<SignInPageViewModel>();
             builder.Services.AddSingleton<SignInPage>();

			 builder.Services.AddSingleton<SignUpPageViewModel>();
             builder.Services.AddSingleton<SignUpPage>();
		
			 builder.Services.AddSingleton<HomePageViewModel>();
             builder.Services.AddSingleton<HomePage>();

		


#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
