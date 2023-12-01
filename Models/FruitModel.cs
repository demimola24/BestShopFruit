// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

using System.ComponentModel;

namespace BestShopFruit.Models {
    public class Nutritions
    {
        public decimal calories { get; set; }
        public decimal fat { get; set; }
        public decimal sugar { get; set; }
        public decimal carbohydrates { get; set; }
        public decimal protein { get; set; }
    }

    public class FruitModel : INotifyPropertyChanged
    {
        public string name { get; set; }
        public int id { get; set; }
        public string family { get; set; }
        public string order { get; set; }
        public string genus { get; set; }
        public string image { get; set; }

        public Nutritions nutritions { get; set; }

        private int _quantity;

  /// <summary>
        /// Gets or sets the quantity of the product in the cart item.
        /// </summary>
        public int quantity
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
