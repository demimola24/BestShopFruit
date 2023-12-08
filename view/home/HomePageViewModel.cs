using System.Diagnostics;
using BestShopFruit.Models;
using BestShopFruit.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BestShopFruit.View.Home
{
    [QueryProperty(nameof(Product), "Product")]
    public partial class HomePageViewModel : BaseViewModel
    {
        private readonly AppService _appService;

         public ObservableCollection<FruitModel> Products { get; } = new ObservableCollection<FruitModel>();

         public ObservableCollection<FruitModel> CartItems { get; private set; } = new ObservableCollection<FruitModel>();

         public ObservableCollection<OrderModel> OrderItems { get; private set; } = new ObservableCollection<OrderModel>();

         

        private bool isFirstRun;

        [ObservableProperty]
        FruitModel product;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePageViewModel"/> class.
        /// </summary>
        /// <param name="appService">The authentication service.</param>
        public HomePageViewModel(AppService appService)
        {
            _appService = appService;
            isFirstRun = true;
        }

        public HomePageViewModel(){}

         [RelayCommand]
        private async Task ProductTapped(FruitModel product)
        {
            if (product == null)
            {
                return;
            }

            var navigationParameter = new Dictionary<string, object>
            {
                { "Product", product },
            };
          

            await Shell.Current.GoToAsync($"{nameof(ProductDetailsPage)}", true, navigationParameter);
        }


        [RelayCommand]
         public async Task Init()
        {
            if (isFirstRun)
            {
               await GetProductsAsync();                                
                isFirstRun = false;
            }
        }

        [RelayCommand]
        public async Task AddToCart(FruitModel product)
        {
            Debug.WriteLine("Called AddToCart");

            if (IsBusy)
            {
                Debug.WriteLine($"Unable to delete cart: Is Busy");
                return;
            }

            try
            {
                if(!CartItems.Contains(product)){
                   product.quantity =1;
                   CartItems.Add(product);
                   await Shell.Current.DisplayAlert("Added", "Item added to cart", "Ok");
                 }else{
                    await Shell.Current.DisplayAlert("Duplicate", "Item has already been added to cart:", "Ok");
                 }                                    
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to delete cart: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Unable to delete cart:", "Ok");
            }
            finally
            {
                IsBusyWithCartModification = false;
            }
        }

        private async Task GetProductsAsync()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                var products = await _appService.GetFruitsAsync();
                Products.Clear();
                foreach (var product in products)
                {
                    Products.Add(product);
                }
            }
            catch (Exception ex)
            {
                 Debug.WriteLine($"Unable to get products: {ex.Message}");
                  await Application.Current.MainPage.DisplayAlert("Error!", $"Unable to get products: {ex.Message}", "OK");   
        
            }
            finally
            {
                IsBusy = false;
            }
        }



        [RelayCommand]
        public async Task DeleteCart()
        {
            if (IsBusy || IsBusyWithCartModification)
            {
                return;
            }

            try
            {
               CartItems.Clear();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to delete cart: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Unable to delete cart:", "Ok");
            }
            finally
            {
                IsBusyWithCartModification = false;
            }
        }

        [RelayCommand]
        public void IncreaseProductQuantity(FruitModel product)
        {
            try
            {
                var found = CartItems.Single(x=>x.id == product.id); 
                var index = CartItems.IndexOf(found);                  
                CartItems.Remove(product);                
                found.quantity = found.quantity+ 1;                                            
                CartItems.Insert(index,found);
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to increase product quantity: {ex.Message}");
                Shell.Current.DisplayAlert("Error", "Unable to increase product quantity", "Ok");
            }
        }

    
        [RelayCommand]
        public void DecreaseProductQuantity(FruitModel product)
        {
            try
            {
                if(product.quantity<1){ return;}
                
                var found = CartItems.Single(x=>x.id == product.id);   
                var index = CartItems.IndexOf(found);         
                CartItems.Remove(product);
                found.quantity = found.quantity- 1;            
                CartItems.Insert(index,found);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to decrease product quantity: {ex.Message}");
                Shell.Current.DisplayAlert("Error", "Unable to decrease product quantity", "Ok");
            }
        }

        [RelayCommand]
        public async Task CompleteOrder()
        {
            try
            {
                await Shell.Current.GoToAsync($"{nameof(OrderSuccessPage)}");  
                var order = new OrderModel();            
                order.id = $"Order-MBSF-{OrderItems.Count+1}";
                order.quantity = $"{CartItems.Count} Items";
                OrderItems.Add(order);
                CartItems.Clear();                          
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to complete order: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Unable to complete order ", "Ok");
            }
        }


    }
    
}
