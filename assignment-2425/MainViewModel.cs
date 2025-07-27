using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace assignment_2425 {

    public class MainViewModel
    {
        public ObservableCollection<PromoItem> PromoItems { get; set; }

        public ObservableCollection<FoodItem> PopularItems { get; set; }
        public ObservableCollection<Restaurant> NearbyPlaces { get; set; }
        public Command<Restaurant> PlaceTappedCommand { get; }
        public ICommand PlaceTapppedCommand { get; }
        public MainViewModel()
        {
            
            PromoItems = new ObservableCollection<PromoItem>
            {

                new PromoItem{ Title = "Dixy Chicken 50% OFF! Free Delivery", Image = "dixypromo.jpeg" },


            };

            PopularItems = new ObservableCollection<FoodItem>
            {

                new FoodItem{ Name = "Asda", Image = "asda.png"},
                new FoodItem{ Name = "Tesco" , Image = "tesco.png"},
                new FoodItem{ Name = "McDonald's", Image = "maccies.png"},
                new FoodItem{ Name = "KFC", Image = "kfc.png"},
                new FoodItem{ Name = "Nando's", Image = "nandos.png"},
                new FoodItem{ Name = "Aldi", Image = "aldi.png"},
                new FoodItem{ Name = "Dixy's", Image = "dixys.png"}

            };

            NearbyPlaces = new ObservableCollection<Restaurant>
            { 
            
                new Restaurant{Name = "DIXY's" , Image = "dixys.png"},
                new Restaurant{Name = "McDonald's", Image = "maccies.png"},
                new Restaurant{Name = "KFC", Image = "kfc.png"},
                new Restaurant{Name = "Nando's", Image = "nandos.png"}
                
            };
            PlaceTappedCommand = new Command<Restaurant>(OnPlaceTapped);
        }
        private void OnPlaceTapped(Restaurant tappedPlace) 
        {
            foreach (var place in NearbyPlaces) {
                place.IsSelected = place == tappedPlace;
            }

            foreach (var item in PopularItems) {
                item.IsSelected = item.Name == tappedPlace.Name;
            }
        }
    }
    public class PromoItem 
    { 
        public string Title { get; set; } 
        public string Image { get; set; }
    
    }
    public class FoodItem :INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Image { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public class Restaurant :INotifyPropertyChanged
    { 
        public string Name { get; set; }
        public string Image { get; set; }

        private bool _isSelected;
        public bool IsSelected 
        {
            get => _isSelected;
            set 
            {
                if (_isSelected != value) 
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}