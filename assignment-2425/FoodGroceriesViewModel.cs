
using System.Collections.ObjectModel;

namespace assignment_2425 
{
    public class FoodGroceriesViewModel
    { 
        public ObservableCollection<Store> PopularStores { get; set; }
        public ObservableCollection<Item> Essentials { get; set; }
        public ObservableCollection<Item> OrderAgain { get; set; }
        public FoodGroceriesViewModel() 
        {

            PopularStores = new ObservableCollection<Store>
            { 
                new() {Name = "Asda"},
                new() {Name = "Dixy Chicken"},
                new() {Name = "Tesco"}
            };

            Essentials = new ObservableCollection<Item>
            { 
                new() {Name = "Milk"},
                new() {Name = "Bread"},
                new() {Name = "Cereal"}
            };

            OrderAgain = new ObservableCollection<Item>
            {
                new() {Name = "Burger"},
                new() {Name = "Tacos"}
            };      
        }
    }

    public class Store { public string Name { get; set; } }
    public class Item {  public string Name { get; set; } }

}