using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using BestShopFruit.Models;

namespace BestShopFruit.View.Onboarding
{
    public partial class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<CarouselItem> CarouselItems { get; set; } = new();
        public MainPageViewModel()
        {

            CarouselItems.Add(new CarouselItem()
            {
                Title = "Best Shop Fruit",
                Description = "Organic fruit enjoyed by everyone",
                Image = "slide3.png"
            });

            CarouselItems.Add(new CarouselItem()
            {
                Title = "Fresh & Healthy",
                Description = "Get fresh and healthy fruit for you",
                Image = "slide2.png"
            });

            CarouselItems.Add(new CarouselItem()
            {
                Title = "Health Guide Tips",
                Description = "Info on useful vitamins tips",
                Image = "slide1.png"
            });

        }
    }
}
