// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

using System.ComponentModel;

namespace BestShopFruit.Models {


    public class OrderModel : INotifyPropertyChanged
    {        
        public string id { get; set; }                

        private string _quantity;

  /// <summary>
        /// Gets or sets the quantity of the product in the cart item.
        /// </summary>
        public string quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(quantity));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
